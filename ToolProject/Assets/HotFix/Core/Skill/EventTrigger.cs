using System.Collections;
using System.Collections.Generic;
using System;
namespace ZFramework.Skill.Trigger
{
    public class EventTrigger : Singleton<EventTrigger>
    {
        private Dictionary<int, Action<NotifyParam>> actDic = new Dictionary<int, Action<NotifyParam>>();

        private Hashtable actTab = new Hashtable();

        public void Add(int state,object target,Action<NotifyParam> dlg)
        {
            if (dlg == null || target == null) return;
            //本次事件已经监听
            if (actTab.ContainsKey(dlg))
                return;
            if (actDic.ContainsKey(state))
                actDic[state] += dlg;
            else
                actDic.Add(state, dlg);
            actTab.Add(dlg,target);
        }

        public void Remove(int state,object target,Action<NotifyParam> dlg)
        {
            if (!actTab.ContainsKey(dlg))
                return;
            actTab.Remove(dlg);
        }

        public void RemoveAll(object target)
        {
            List<object> list = new List<object>();
            foreach (var okey in actTab.Keys)
            {
                if (actTab[okey].Equals(target))
                {
                    list.Add(okey);
                }
            }

            foreach (var o in list)
            {
                actTab.Remove(o);
            }
        }

        public void Trigger(int state,NotifyParam param = null)
        {
            if (!actDic.ContainsKey(state)) return;
            Delegate[] dlgs = actDic[state].GetInvocationList();

            for (int i = 0; i < dlgs.Length; i++)
            {
                var dlg = (Action<NotifyParam>)dlgs[i];
                if (actTab.ContainsKey(dlg))
                    dlg.Invoke(param);
                else
                {
                    if(actDic.ContainsKey(state))
                    {
                        actDic[state] -= dlg;
                        if (actDic[state] == null)
                            actDic.Remove(state);
                    }
                }
            }
        }

    }
}
