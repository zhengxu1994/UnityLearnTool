using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ZFramework.FSM
{
    public sealed class DecisionFSM : FSMSystem
    {

        public static DecisionFSM CreateDecisionFSM(GameEntity entity)
        {
            var fsm = new DecisionFSM();

            DecisionIdle idleState = new DecisionIdle(fsm, entity);
            idleState.AddTransId(TransId.DecisionDie, StateID.DecisionDie);
            idleState.AddTransId(TransId.DecisionIdle, StateID.DecisionIdle);
            idleState.AddTransId(TransId.DecisionMove, StateID.DecisionMove);
            idleState.AddTransId(TransId.DecisionChant, StateID.DecisionChant);
            idleState.AddTransId(TransId.DecisionAttack, StateID.DecisionAttack);
            idleState.AddTransId(TransId.DecisionUnControl, StateID.DecisionUnControl);

            DecisionMove moveState = new DecisionMove(fsm, entity);
            moveState.AddTransId(TransId.DecisionDie, StateID.DecisionDie);
            moveState.AddTransId(TransId.DecisionIdle, StateID.DecisionIdle);

            DecisionAttack attackState = new DecisionAttack(fsm, entity);
            attackState.AddTransId(TransId.DecisionDie, StateID.DecisionDie);
            attackState.AddTransId(TransId.DecisionIdle, StateID.DecisionIdle);

            DecisionChant chantState = new DecisionChant(fsm, entity);
            chantState.AddTransId(TransId.DecisionDie, StateID.DecisionDie);
            chantState.AddTransId(TransId.DecisionIdle, StateID.DecisionIdle);

            DecisionAbnormalState unControlState = new DecisionAbnormalState(fsm, entity);
            unControlState.AddTransId(TransId.DecisionDie, StateID.DecisionDie);
            unControlState.AddTransId(TransId.DecisionIdle, StateID.DecisionIdle);

            DecisionNearDie nearDieState = new DecisionNearDie(fsm, entity);
            nearDieState.AddTransId(TransId.DecisionDie, StateID.DecisionDie);

            DecisionDie dieState = new DecisionDie(fsm, entity);
            dieState.AddTransId(TransId.DecisionDie, StateID.DecisionDie);
            dieState.AddTransId(TransId.DecisionNearDie, StateID.DecisionNearDie);
            dieState.AddTransId(TransId.DecisionIdle, StateID.DecisionIdle);

            fsm.AddState(idleState);
            fsm.AddState(moveState);
            fsm.AddState(attackState);
            fsm.AddState(chantState);
            fsm.AddState(unControlState);
            fsm.AddState(nearDieState);
            fsm.AddState(dieState);
            return fsm;
        }
    }


    public enum StateID
    {
        NullStateID,
        DecisionIdle,
        DecisionMove,
        DecisionAttack,
        DecisionForceAttack,
        DecisionUnControl,
        DecisionChant,
        DecisionNearDie,
        DecisionDie
    }

    public enum TransId
    {
        NullTransID,
        DecisionIdle,
        DecisionMove,
        DecisionAttack,
        DecisionForceAttack,
        DecisionUnControl,
        DecisionChant,
        DecisionNearDie,
        DecisionDie
    }
}
