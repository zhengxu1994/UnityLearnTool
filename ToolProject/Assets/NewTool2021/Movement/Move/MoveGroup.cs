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

        public override void DisplacementTo(TSVector2 target, FP speed)
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

        public override int direction { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override bool isMoving => throw new NotImplementedException();
    }
}
