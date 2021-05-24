﻿using System;
using UnityEngine;

namespace ZFramework.FSM
{
    public class DecisionAttack : DecisionFSMState
    {
        public DecisionAttack(FSMSystem fsm, FSMEntity entity) : base(fsm, entity)
        {

        }

        public override bool Reason()
        {
            if (!base.Reason()) return false;
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
