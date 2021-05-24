using System;
namespace ZFramework.FSM
{
    /// <summary>
    /// 眩晕
    /// </summary>
    public class DecisionDizzy : DecisionFSMState
    {
        public DecisionDizzy(FSMSystem fsm, FSMEntity entity) : base(fsm, entity)
        {

        }

        public override bool Reason()
        {
            if (!base.Reason()) return false;
            if (!entity.alive || entity.abnormalStates.ContainsKey(AbnormalState.Dizzy))
            {
                fsm.PerformTransId(TransId.DecisionUnControl);
                return false;
            }
            return true;
        }

        public override void Action()
        {
            LogTool.LogWarning("眩晕中~");
        }

        public override void DoBeforeLeaving()
        {
            entity.canAttack = true;
            entity.canMove = true;
            entity.canChanting = true;
        }

        public override void DoBeforeEntering()
        {
            entity.canAttack = false;
            entity.canMove = false;
            entity.canChanting = false;
        }
    }
}
