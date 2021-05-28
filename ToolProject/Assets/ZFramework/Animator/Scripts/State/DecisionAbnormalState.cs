using System;
using UnityEngine;
namespace ZFramework.FSM
{
    public class DecisionAbnormalState : DecisionFSMState
    {
        public DecisionAbnormalState(FSMSystem fsm, FSMEntity entity) : base(fsm, entity)
        {
            stateID = StateID.DecisionUnControl;
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
            //各种异常状态处理，存在优先级和混合
        }

        public override void DoBeforeLeaving()
        {
            LogTool.LogError("异常解除");
        }

        public override void DoBeforeEntering()
        {
            LogTool.LogError("受到了异常状态");
        }
    }
}