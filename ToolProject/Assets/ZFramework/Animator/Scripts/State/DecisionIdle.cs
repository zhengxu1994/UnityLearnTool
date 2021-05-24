using System;
using UnityEngine;

namespace ZFramework.FSM
{
    public class DecisionIdle : DecisionFSMState
    {
        public DecisionIdle(FSMSystem fsm, FSMEntity entity) : base(fsm, entity)
        {
            stateID = StateID.DecisionIdle;
        }

        public override bool Reason()
        {
            if (!base.Reason()) return false;
            //死亡优先级最高
            return true;
        }

        public override void Action()
        {
            base.Action();
        }

        public override void DoBeforeEntering()
        {
            //切换到待机动画
        }

        public override void DoBeforeLeaving()
        {
            //
        }
    }
}
