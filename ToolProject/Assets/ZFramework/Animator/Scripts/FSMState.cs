using System;
using UnityEngine;
using System.Collections.Generic;
namespace ZFramework.FSM
{
    public abstract class FSMState
    {
        protected FSMSystem fsm = null;
        protected GameEntity entity = null;
        protected StateID minStateId, maxStateId;
        protected TransId minTrans, maxTrans;
        protected Dictionary<TransId, StateID> stateMap = new Dictionary<TransId, StateID>();
        protected StateID stateID;


        public StateID ID { get { return stateID; } }

        private bool IsStateValid(StateID id)
        {
            return id >= minStateId && id <= maxStateId;
        }

        private bool IsTransValid(TransId id)
        {
            return id >= minTrans && id <= maxTrans;
        }

        public virtual void AddTransId(TransId trans,StateID id)
        {
            if (trans == TransId.NullTransID)
                return;
            if (id == StateID.NullStateID)
                return;
            if (!IsTransValid(trans))
                return;
            if (!IsStateValid(id))
                return;
            if (stateMap.ContainsKey(trans))
                return;
            stateMap.Add(trans, id);
        }

        public virtual void DeleteTransId(TransId trans)
        {
            if (trans == TransId.NullTransID)
                return;
            if (!IsTransValid(trans))
                return;
            if(stateMap.ContainsKey(trans))
            {
                stateMap.Remove(trans);
                return;
            }    
        }

        public FSMState(FSMSystem fsm, GameEntity entity)
        {
            this.fsm = fsm;
            this.entity = entity;
        }

        public StateID GetOutpuState(TransId trans)
        {
            if (!IsTransValid(trans))
                return StateID.NullStateID;
            if (stateMap.ContainsKey(trans))
                return stateMap[trans];
            return StateID.NullStateID;
        }



        public virtual void DoBeforeLeaving()
        {

        }

        public virtual void DoBeforeEntering()
        {

        }

        public virtual bool Reason()
        {
            DecisionTool.Inst.Check(entity);
            return true;
        }

        public virtual void Action()
        {

        }
    }
}
