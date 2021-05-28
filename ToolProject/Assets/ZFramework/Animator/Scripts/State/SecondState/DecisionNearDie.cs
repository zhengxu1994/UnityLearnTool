using System;
namespace ZFramework.FSM
{
    /// <summary>
    /// 濒临死亡
    /// </summary>
    public class DecisionNearDie : DecisionFSMState
    {
        //Test
        private int Num = 100;
        public DecisionNearDie(FSMSystem fsm, FSMEntity entity) : base(fsm, entity)
        {
            stateID = StateID.DecisionNearDie;
        }

        public override bool Reason()
        {
            if (!base.Reason()) return false;
            if(entity.dieImmediately || (entity.dieImmediately == false && entity.alive))
            {
                fsm.PerformTransId(TransId.DecisionDie);
                return false;
            }
            return true;
        }

        public override void Action()
        {
            LogTool.LogError("呼喊救命~");
            //倒计时 倒计时结束 死亡
            Num--;
            if (Num <= 0)
                entity.dieImmediately = true;
        }

        public override void DoBeforeLeaving()
        {
            if (entity.dieImmediately)
                LogTool.LogError("没人救我");
            else if (entity.dieImmediately == false && entity.alive)
            {
                LogTool.LogError("终于有人救我了");
            }
        }

        public override void DoBeforeEntering()
        {
            LogTool.Log("濒临死亡ing");
            Num = 100;
        }
    }
}
