using System;
using TrueSync;
using UnityEngine;
namespace ZFramework.FSM
{
    /// <summary>
    /// 濒临死亡
    /// </summary>
    public class DecisionNearDie : DecisionFSMState
    {
        //Test
        private int Num = 10;
        private FP tempTime = 0;
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
            LogTool.LogWarning("呼喊救命~");
            //倒计时 倒计时结束 死亡
            tempTime += Time.deltaTime;
            if (tempTime >= Num)
                entity.dieImmediately = true;
        }

        public override void DoBeforeLeaving()
        {
            if (entity.dieImmediately)
                LogTool.LogWarning("没人救我");
            else if (entity.dieImmediately == false && entity.alive)
            {
                LogTool.LogWarning("终于有人救我了");
            }
        }

        public override void DoBeforeEntering()
        {
            LogTool.LogWarning("濒临死亡ing");
            Num = 10;
            tempTime = 0;
        }
    }
}
