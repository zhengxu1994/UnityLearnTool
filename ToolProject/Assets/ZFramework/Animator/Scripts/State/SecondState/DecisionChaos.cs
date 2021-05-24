using System;
namespace ZFramework.FSM
{
    /// <summary>
    /// 混乱
    /// </summary>
    public class DecisionChaos : DecisionFSMState
    {
        public DecisionChaos(FSMSystem fsm, FSMEntity entity) : base(fsm, entity)
        {

        }

        public override bool Reason()
        {
            if (!base.Reason()) return false;
            //死亡 或者离开恐惧状态
            if (!entity.alive || !entity.abnormalStates.ContainsKey(AbnormalState.Chaos))
            {
                fsm.PerformTransId(TransId.DecisionUnControl);
                return false;
            }
            return true;
        }

        public override void Action()
        {
            //四处移动
            entity.RandomMove();
        }

        public override void DoBeforeLeaving()
        {
            entity.chanting = true;
            entity.canChanting = true;
            entity.canAttack = true;
            entity.attacking = true;
            LogTool.LogError("恐惧散去");
        }

        public override void DoBeforeEntering()
        {
            entity.chanting = false;
            entity.canChanting = false;
            entity.canAttack = false;
            entity.attacking = false;
            LogTool.LogError("恐惧～");
        }
    }
}
