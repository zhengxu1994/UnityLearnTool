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
        public DecisionNearDie(FSMSystem fsm, GameEntity entity) : base(fsm, entity)
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
            Log.Warning("呼喊救命~");
            //倒计时 倒计时结束 死亡
            tempTime += Time.deltaTime;
            if (tempTime >= Num)
                entity.dieImmediately = true;
        }

        public override void DoBeforeLeaving()
        {
            if (entity.dieImmediately)
                Log.Warning("没人救我");
            else if (entity.dieImmediately == false && entity.alive)
            {
                Log.Warning("终于有人救我了");
            }
        }

        public override void DoBeforeEntering()
        {
            Log.Warning("濒临死亡ing");
            Num = 10;
            tempTime = 0;
        }
    }
}
