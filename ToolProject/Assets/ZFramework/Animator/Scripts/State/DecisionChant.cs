using System;
using UnityEngine;
namespace ZFramework.FSM
{
    public class DecisionChant : DecisionFSMState
    {
        public DecisionChant(FSMSystem fsm, FSMEntity entity) : base(fsm, entity)
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

        }

        public override void DoBeforeEntering()
        {

        }
    }
}
