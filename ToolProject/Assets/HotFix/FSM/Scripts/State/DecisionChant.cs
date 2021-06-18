using System;
using UnityEngine;
namespace ZFramework.FSM
{
    public class DecisionChant : DecisionFSMState
    {
        public DecisionChant(FSMSystem fsm, GameEntity entity) : base(fsm, entity)
        {
            stateID = StateID.DecisionChant;
        }

        public override bool Reason()
        {
            if (!base.Reason()) return false;
            if(!entity.alive)
            {
                fsm.PerformTransId(TransId.DecisionDie);
                return false;
            }
            if (!entity.chanting)
            {
                fsm.PerformTransId(TransId.DecisionIdle);
                return false;
            }
            return true;
        }

        public override void Action()
        {
            
        }

        public override void DoBeforeLeaving()
        {
            LogTool.Log("离开吟唱");
        }

        public override void DoBeforeEntering()
        {
            LogTool.Log("进入吟唱");
        }
    }
}
