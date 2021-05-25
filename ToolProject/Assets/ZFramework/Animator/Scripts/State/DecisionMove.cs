using System;
using UnityEngine;

namespace ZFramework.FSM
{
    public class DecisionMove : DecisionFSMState
    {
        public DecisionMove(FSMSystem fsm, FSMEntity entity) : base(fsm, entity)
        {

        }

        public override bool Reason()
        {
            if (!base.Reason()) return false;
            if (!entity.alive)
            {
                fsm.PerformTransId(TransId.DecisionDie);
                return false;
            }
            //受到控制 ，不能移动 ， 结束移动
            if (!entity.isControl || !entity.canMove || !entity.isMoving)
            {
                fsm.PerformTransId(TransId.DecisionIdle);
                return false;
            }
            return true;
        }

        public override void Action()
        {
            //往目标点移动
            DecisionTool.Inst.MoveToTarget(entity);
            //如果不是强制移动，则搜索附近可以攻击的敌人 并移动过去
            DecisionTool.Inst.SearchAtkTarget(entity);
        }

        public override void DoBeforeLeaving()
        {

        }

        public override void DoBeforeEntering()
        {

        }
    }
}