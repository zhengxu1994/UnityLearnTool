using System;
using UnityEngine;

namespace ZFramework.FSM
{
    public class DecisionIdle : DecisionFSMState
    {
        public DecisionIdle(FSMSystem fsm, GameEntity entity) : base(fsm, entity)
        {
            stateID = StateID.DecisionIdle;
        }

        public override bool Reason()
        {
            if (!base.Reason()) return false;
            //死亡优先级最高
            if(!entity.alive)
            {
                fsm.PerformTransId(TransId.DecisionDie);
                return false;
            }
            //受控制次优先级
            if(entity.isControl)
            {
                //什么事情都不能做
                fsm.PerformTransId(TransId.DecisionUnControl);
                return false;
            }
            if(entity.chanting)
            {
                fsm.PerformTransId(TransId.DecisionChant);
                return false;
            }
            if (entity.isMoving && entity.canMove)
            {
                fsm.PerformTransId(TransId.DecisionMove);
                return false;
            }
            if(entity.canAttack && entity.attacking)
            {
                fsm.PerformTransId(TransId.DecisionAttack);
                return false;
            }
            return true;
        }

        public override void Action()
        {
            LogTool.Log("Idle======");
            //搜索目标
            if (entity.atkTarget == null)
                DecisionTool.Inst.SearchAtkTarget(entity);
        }

        public override void DoBeforeEntering()
        {
            //切换到待机动画
            LogTool.Log("切换待机状态");
        }

        public override void DoBeforeLeaving()
        {
            //
            LogTool.Log("离开待机状态");
        }
    }
}
