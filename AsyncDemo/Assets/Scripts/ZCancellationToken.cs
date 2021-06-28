using System;
using System.Collections.Generic;
namespace ZFramework
{
    public class ZCancellationToken
    {
        private HashSet<Action> actions = new HashSet<Action>();

        public void Add(Action callback)
        {
            this.actions.Add(callback);
        }

        public void Remove(Action callback)
        {
            this.actions?.Remove(callback);
        }

        public bool IsCancel()
        {
            return this.actions == null;
        }

        public void Cancel()
        {
            if (this.actions == null)
                return;
            this.Invoke();
        }

        private void Invoke()
        {
            HashSet<Action> runActions = this.actions;
            this.actions = null;
            try
            {
                foreach (var action in actions)
                {
                    action.Invoke();
                }
            }
            catch(Exception e)
            {
                //
            }
        }
    }
}
