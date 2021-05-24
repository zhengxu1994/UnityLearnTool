using System;
using UnityEngine;
namespace ZFramework.FSM
{
    public class DecisionDie : DecisionFSMState
    {
        public DecisionDie(FSMSystem fsm, FSMEntity entity) : base(fsm, entity)
        {

        }

        public override bool Reason()
        {
            return base.Reason();
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