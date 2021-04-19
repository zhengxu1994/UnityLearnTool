using System;
using System.Collections.Generic;
using TrueSync;
using UnityEngine;

namespace Movement
{
    public enum MoveState
    {
        Stand = 0,
        KeepOffFailed,
        ReachGoal,
        LineUpEnd,
        WaitForPath,
        Displacement,
        DisplacementByTime,
        IncrementWayPoint,
        MoveToLineUp,
        CloseToTarget
    }

    public enum CollisionUnit
    {
        NotCollision = 0,
        NearByCollision ,
        BlockCollision,
        HardCollision
    }

    public enum UnitFlag
    {
        None = 0,
        Soldier =1,
        Captain = 2,
        Group = 4,
        Obstruct = 8
    }
    public class MoveUnit : MoveUniform<MoveUnit>
    {

        public MoveState moveState { get; protected set; } = MoveState.Stand;

        public UnitFlag flag { get; set; }

        public int camp { get; protected set; }

        private FP _moveSpeed;

        public override FP moveSpeed
        {
            get
            {
                return _moveSpeed;
            }
            set
            {
                _moveSpeed = value;
                moveParty.speed = _moveSpeed;
                moveStep = _moveSpeed == 0 ? 0 : moveDelta * _moveSpeed;
                stepTick = _moveSpeed == 0 ? 0 : (radius / moveStep).AsInt();
            }

        }

        public override TSVector2 position { get => moveParty.position; set => moveParty.position = value; }

#if !SERVER
        public GameObject gameobject => moveParty.gameObject;
#endif

        public MoveGroup moveGroup { get; protected set; }

        public MoveParty moveParty { get; protected set; }

        public int uid { get; protected set; }

        public bool isLeader {
            get
            {
                if (moveGroup != null)
                    return moveGroup.isLeader(uid);
                return false;
            }
        }

        public int gid
        {
            get
            {
                if (moveGroup != null)
                    return moveGroup.gid;
                return MoveMgr.InvalidUid;
            }
        }

        public override int direction { get => moveParty.dir; set => moveParty.dir = value; }

        public override bool isMoving
        {
            get
            {
                if (!moveParty.reached)
                    return true;
                return false;
            }
        }

        public FP moveDelta { get; set; } = 1f / 30f;
        public FP moveStep;

        public int stepTick;

        public const int collisionSQ = 576;
        public const int radius = 12;
        public const int radiusSQ = 144;

        public int atkRangeSQ { get; private set; } = 1225;
        const int nearbySQ = 900;
        const int slowDownSQ = 1225;

        int _atkRange = 35;
        public int atkRange
        {
            get => _atkRange;
            set
            {
                _atkRange = value;
                atkRangeSQ = _atkRange * _atkRange;
            }
        }

        public DirPos formationOffset{ get; set; }
        public int formationIdx { get; set; }

        public List<TSVector2> waypoints;
        int waypointIdx;
        public TSVector2 moveGoal;
        TSVector2 nextPoint;
        int nextDir;

        bool moveToGoalBySelf = false;
        bool scatterFromGoal = false;

        TSVector2 displacementPos;
        FP displaceSpeed;

        TSVector2 displaceVector;
        int displaceTime = 0;
        int hasDisplaceTime = 0;
        TSVector2[] displacePath;
        private int startTime = 0;
        private Action deleyCB;

        TSVector2 dropVector;
        int dropDis = 20;
        int dropTime = 5;
        bool hasBezier = false;

        public static readonly FP SOLDIER_ARROW_HIGHT_FACTOR = 0.8f;

        public override Action<StopCause, MoveUnit> moveStopCB { get; set; }

        public MoveUnit(MoveParty moveParty,int uid,int camp,MoveGroup moveGroup = null)
        {
            this.uid = uid;
            this.camp = camp;
            this.moveParty = moveParty;
            this.moveGroup = moveGroup;
#if UNITY_EDITOR
            this.moveParty.id = uid;

#endif
        }

        public override void DisplacementTo(TSVector2 target, FP speed)
        {
            displacementPos = target;
            displaceSpeed = speed;
            direction = Calculater.GetDirByPos(position, displacementPos);
        }

        public void DisplacementTo(int time,TSVector2 endPoint,int startTime,Action cb = null)
        {
            var dirVector = endPoint - position;
            displaceVector = dirVector / time;
            displacementPos = endPoint;
            displaceTime = time;
            hasDisplaceTime = 0;

            dropVector = dirVector.normalized * dropDis;
            var dropPoint = endPoint - dropVector;
            deleyCB = cb;
            InitPathByBezier(dropPoint, startTime);

            if (displacePath != null && displacePath.Length > 0)
                moveState = MoveState.DisplacementByTime;
            else
                position = endPoint;
        }

        public void DisplacementTo(int time,TSVector2 endPoint,Action cb)
        {
            var dirVector = endPoint - position;
            displaceVector = dirVector / time;
            displacementPos = endPoint;
            displaceTime = time;
            direction = Calculater.GetDirByPos(position, endPoint);
            hasDisplaceTime = 0;
            moveState = MoveState.DisplacementByTime;
            hasBezier = false;
            deleyCB = cb;
        }

        private void InitPathByBezier(TSVector2 endPos,int startTime)
        {
            this.startTime = startTime;
            var controlPos = new TSVector2((position.x + endPos.x) / 2, (position.y + endPos.y) / 2 + TSMath.Abs(position.x - endPos.x) * SOLDIER_ARROW_HIGHT_FACTOR);
            displacePath = Calculater.GetPathByBezier(position, controlPos, endPos, displaceTime - dropTime - startTime);
            dropVector /= dropTime;
            hasBezier = true;
        }

        public bool IsOnFormation()
        {
            if (moveToGoalBySelf)
                return true;
            if (moveState == MoveState.KeepOffFailed || moveState == MoveState.ReachGoal)
                return true;
            if (position != (formationOffset.pos + moveGroup.position))
                return false;
            return true;
        }

        void MoveByPath(List<TSVector2> path)
        {
            if(waypoints != null)
            {
                waypoints = path;
                moveGoal = waypoints[waypoints.Count - 1];
                moveParty.reached = true;
                waypointIdx = 0;
                nextPoint = waypoints[waypointIdx];
                if (MapMgr.Inst.IsCollisionBlock(nextPoint))
                    nextPoint = MapMgr.Inst.PosToCenter(nextPoint);
                MoveToNextPoint();
            }
        }

        void MoveToNextPoint()
        {
            if (waypoints == null) return;
            moveParty.target = nextPoint;
            moveState = MoveState.IncrementWayPoint;
        }

        public void MoveToPosition(TSVector2 target)
        {
            moveGoal = MapMgr.Inst.PosToCenter(target);
            direction = Calculater.GetDirByPos(position, moveGoal);
            moveState = MoveState.CloseToTarget;
            //CheckMoveToNext();
        }

        public void ApproachTarget(int uid)
        {
            if (targetPrey != null && targetPrey.uid == uid)
                return;
            //var unit = MoveMgr.Inst.GetMoveUnit(uid);
            //if(unit != null)
            //{
            //    targetPrey = null;
            //    direction = Calculater.GetDirByPos(position, targetPrey.position);
            //    moveState = MoveState.CloseToTarget;
            //    CheckMoveToNext();
            //}
        }

        //bool CheckStandSpace()
        //{
        //    var uids = MoveMgr.Inst.GetUnitsInCell(position, -1, uid);
        //    if(uids.Count > 0)
        //    {

        //    }
        //}

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
    }
}