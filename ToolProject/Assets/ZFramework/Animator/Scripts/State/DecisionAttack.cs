using System;
using UnityEngine;

namespace ZFramework.FSM
{
    public class DecisionAttack : DecisionFSMState
    {
        public DecisionAttack(FSMSystem fsm, FSMEntity entity) : base(fsm, entity)
        {
            stateID = StateID.DecisionAttack;
        }

        public override bool Reason()
        {
            if (!base.Reason()) return false;
            if(!entity.alive ||entity.isControl || entity.isMoving)
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
