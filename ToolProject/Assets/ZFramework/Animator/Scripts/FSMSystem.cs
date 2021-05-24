using System;
using System.Collections.Generic;
namespace ZFramework.FSM
{
    public abstract class FSMSystem
    {
        private Dictionary<StateID,FSMState> states;

        public StateID CurrentStateID { get; private set;}

        public FSMState CurrentState { get;private set;}

        public FSMSystem()
        {
            states = new Dictionary<StateID, FSMState>();
        }

        public virtual void AddState(FSMState state)
        {
            if(states == null)return;
            if(states.Count == 0)
            {
                CurrentState = state;
                CurrentStateID = state.ID;
            }
            else if(states.ContainsKey(state.ID))
            {
                return;
            }
            states.Add(state.ID,state);
        }


        public virtual void DeleteState(StateID id)
        {
            if(!states.ContainsKey(id))return;

            states.Remove(id);
        }

        public virtual void PerformTransId(TransId trans)
        {
            if(trans == TransId.NullTransID)return;
            StateID id = CurrentState.GetOutpuState(trans);

            if(id == StateID.NullStateID)
            {
                return;
            }

            if(states.ContainsKey(id))
            {
                CurrentState.DoBeforeLeaving();

                CurrentState = states[id];
                CurrentStateID = id;

                CurrentState.DoBeforeEntering();
            }
        }

        public void Run()
        {
            if(CurrentState.Reason())
                CurrentState.Action();
        }
    }
}
