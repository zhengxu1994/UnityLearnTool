using System;
using UnityEngine;

namespace ZFramework.FSM
{
    public abstract class DecisionFSMState : FSMState
    {
        protected DecisionFSMState(FSMSystem fsm, GameEntity entity) : base(fsm, entity)
        {
            minStateId = StateID.DecisionIdle;
            maxStateId = StateID.DecisionDie;
            minTrans = TransId.DecisionIdle;
            maxTrans = TransId.DecisionDie;
        }
    }
}