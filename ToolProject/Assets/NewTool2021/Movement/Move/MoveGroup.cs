using System;
using System.Collections;
using System.Collections.Generic;
using TrueSync;
namespace Movement
{
    public enum GroupState
    {
        FreeStand = 0,
        FormationStand,
        GroupReached,
        DisplaceWait,
        Displacement,
        DisplacementByTime,
        LineUp,
        FormationMove,
        FreeAttack
    }
    public class MoveGroup : MoveUniform<MoveGroup>
    {
        public UnitFlag flag { get; set; }

        public GroupState groupState { get; protected set; }

        int _captainUid = MoveMgr.InvalidUid;

        public int captainUid
        {
            get => _captainUid;
            protected set
            {
                _captainUid = value;
                if (_captainUid != MoveMgr.InvalidUid)
                {
                    if (moveUnits.TryGetValue(_captainUid, out var leader))
                    {
                        leaderUnit = leader;
                        leader.flag = UnitFlag.Captain;
                    }
                }
            }
        }

        public override FP moveSpeed
        {
            get
            {
                if (leaderUnit != null)
                    return leaderUnit.moveSpeed;
                foreach (var unit in moveUnits.Values)
                    return unit.moveSpeed;
                return 0;
            }
            set
            {
                foreach (var unit in moveUnits.Values)
                    unit.moveSpeed = value;
            }
        }

        public Formation formation { get; private set; } = null;

        public int radius { get; private set; } = 0;
        private int groupRadius = 0;

        public static float atkDisRate { get; set; } = 1.2f;

        

        public void ChangeFormation(Formation newFormation)
        {
            if(formation != newFormation)
            {
                formation = newFormation;
               // radius = MoveUnit.radius + formationRadius;
               //if (agentSid >= 0)
               //     RVO.Simulator.Instance.setAgentRadius(agentSid, radius);
            }
        }

        public bool isLeader(int uid)
        {
            if (leaderUnit != null) return uid == leaderUnit.uid;
            return false;
        }

        public override void Dispose()
        {
            throw new NotImplementedException();
        }

        public override void LogicUpdate()
        {
            throw new NotImplementedException();
        }

        public override void UpdateStep()
        {
            throw new NotImplementedException();
        }

        public int camp { get; protected set; }

        public int gid { get; protected set; }

        public int formationRadius => (formation == null || unitsNum <= 0) ? 0 : formation.radius[unitsNum - 1];

        public bool keepFormation { get; set; } = false;

        public Dictionary<int, MoveUnit> moveUnits { get; private set; } = new Dictionary<int, MoveUnit>();

        public int unitsNum => moveUnits.Count;

        MoveUnit leaderUnit;
        MoveParty groupPivot;

        public override Action<StopCause,MoveGroup> moveStopCB { get; set; }

#if !SERVER
        public UnityEngine.GameObject gameObject => groupPivot.gameObject;
#endif

#if UNITY_EDITOR
        public List<TSVector2> showPoints;

        public UnityEngine.Vector3 showCenter
        {
            get
            {
                //if (isChargeAttack)
                //    return enemyCenter.ToVector();
                return position.ToVector();
            }
        }
#endif
        public int goalDir;
        public TSVector2 moveGoal = MoveMgr.InvalidPos;

        public override MoveGroup targetPrey { get ; protected set ; }

        public override TSVector2 position
        {
            get => groupPivot.position;
            set {
                groupPivot.position = value;
                foreach (var unit in moveUnits.Values)
                {
                    unit.position = unit.formationOffset.pos + groupPivot.position;
                    
                }
            }
        }

        public override int direction { get => groupPivot.dir; set =>groupPivot.dir = value % 8; }

        public  bool isMoving { get; protected set; }

        private void SetGroupState(GroupState state)
        {
            groupState = state;
            isMoving = groupState == GroupState.FormationMove;
        }

        TSVector2 enemyCenter;
        bool manualMove = false;

        bool isChargeAttack = false;
        int agentSid = -1;
        public void AttackTarget(MoveGroup enemy,bool chargeAttack)
        {
            isChargeAttack = chargeAttack;
            if (isChargeAttack)
            {
                enemyCenter = enemy.position;
                if (agentSid >= 0)
                {
                    RVO.Simulator.Instance.setAgentRelationGroup(agentSid, 0);
                }
            }
        }

        int checkPeryYawTick = 0;
        int manualTargetGid = MoveMgr.InvalidUid;
        public override void TargetDispose(bool targetDead)
        {
            targetPrey = null;
            checkPeryYawTick = 0;

            if (isChargeAttack && agentSid >= 0 && targetDead)
            {
                RVO.Simulator.Instance.setAgentRelationGroup(agentSid, camp + 10);
                var normalVec = (enemyCenter - position).normalized;
                var fightCenter = position + normalVec * radius;
                groupPivot.target = fightCenter;
                var speed = TSVector2.Distance(fightCenter, position) * 30;
                RVO.Simulator.Instance.setAgentMaxSpeed(agentSid, speed);
                RVO.Simulator.Instance.setAgentPrefVelocity(agentSid, normalVec * speed);
            }

            isChargeAttack = false;
            manualTargetGid = MoveMgr.InvalidUid;

            if (isMoving)
                StopMove(StopCause.EnemyDispose, GroupState.FreeStand);
        }

        public void ApproachTarget(int gid,bool isManual = false)
        {
            targetPrey = MoveMgr.Inst.GetMoveGroup(gid);
            if (isManual)
                manualTargetGid = gid;
        }

        TSVector2 displacementPos;
        FP displaceSpeed;
        TSVector2 displaceVector;
        int displaceTime = 0;
        int hasDisplaceTime = 0;
        bool waitingManualMove = false;
        int waitingTick = 0;
        int checkPathYawTick = 0;
        int stopUpTick = 0;

        public override void DisplacementTo(TSVector2 target, FP speed)
        {
            displacementPos = target;
            displaceSpeed = speed;
            if (!OnFromtaion())
            {
                SetGroupState(GroupState.DisplaceWait);
                foreach (var unit in moveUnits.Values)
                {
                    var lineUpPos = unit.formationOffset.pos + displacementPos;
                    unit.DisplacementTo(lineUpPos,speed);
                }
            }
            else
            {
                direction = Calculater.GetDirByPos(position, displacementPos);
                SetGroupState(GroupState.Displacement);
                foreach (var unit in moveUnits.Values)
                    unit.DisplacementTo(target, speed);
            }
        }

        private List<TSVector2> _points = new List<TSVector2>();

        public void ReCalculateRadius()
        {
            _points.Clear();
            foreach (var unit in moveUnits.Values)
            {
                _points.Add(unit.position);
            }
        }

        bool OnFromtaion()
        {
            foreach (var unit in moveUnits.Values)
            {
                if (!unit.IsOnFormation())
                    return false;
            }
            return true;
        }
        public void StopMove(StopCause cause,GroupState endState = GroupState.FreeStand)
        {

        }
    }
}
