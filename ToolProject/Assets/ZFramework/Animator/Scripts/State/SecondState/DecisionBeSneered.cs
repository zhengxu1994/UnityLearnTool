using System;
namespace ZFramework.FSM
{
    /// <summary>
    /// 嘲讽
    /// </summary>
    public class DecisionBeSneered : DecisionFSMState
    {
        public DecisionBeSneered(FSMSystem fsm, FSMEntity entity) : base(fsm, entity)
        {

        }

        public override bool Reason()
        {
            if (!base.Reason()) return false;
            if (!entity.alive || !entity.abnormalStates.ContainsKey(AbnormalState.BeSneered))
            {
                fsm.PerformTransId(TransId.DecisionUnControl);
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
            base.DoBeforeLeaving();
        }

        public override void DoBeforeEntering()
        {
            base.DoBeforeEntering();
        }
    }
}
