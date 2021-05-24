using System;
using UnityEngine;
namespace ZFramework.FSM
{
    public class DecisionUnControl : DecisionFSMState
    {
        public DecisionUnControl(FSMSystem fsm, FSMEntity entity) : base(fsm, entity)
        {

        }

        public override bool Reason()
        {
            if (!base.Reason()) return false;
            if(!entity.alive)
            {
                fsm.PerformTransId(TransId.DecisionDie);
                return false;
            }
            if(!entity.isControl)
            {
                fsm.PerformTransId(TransId.DecisionIdle);
                return false;
            }
            return true;
        }

        public override void Action()
        {
            base.Action();
        }

        public override void DoBeforeLeaving()
        {
            LogTool.LogError("又可以动了");
            entity.canMove = true;
            entity.canAttack = true;
        }

        public override void DoBeforeEntering()
        {
            LogTool.LogError("受到了控制，动不了了");
            entity.canMove = false;
            entity.isMoving = false;
            entity.canAttack = false;
            entity.attacking = false;
            entity.chanting = false;
        }
    }
}