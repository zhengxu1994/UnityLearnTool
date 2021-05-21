using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ZFramework.Skill.Trigger
{
    public delegate void TriggerSkillTrigger(NotifyParam evt,Skill_GameEntity target);
    public delegate void CancelSkillTrigger(NotifyParam evt, Skill_GameEntity target);
    /// <summary>
    /// Trigger管理
    /// </summary>
    public class TriggerManager
    {
        public Dictionary<int, Trigger> triggers = new Dictionary<int, Trigger>();

        public int triggerId = 0;
        public TriggerManager()
        {
            //监听移除
            //Test
        }

        public Trigger CreateTrigger(Skill_GameEntity creater, Skill_GameEntity owner, BattleEvent eventType, TriggerType triggerType,
             TriggerSkillTrigger skillTrigger, CancelSkillTrigger cancelTrigger)
        {
            triggerId++;
            triggers.Add(triggerId, Trigger.Create(creater, owner, eventType, triggerType, triggerId, skillTrigger, cancelTrigger));
            return triggers[triggerId];
        }

        public void RemoveTrigger(int triggerId)
        {
            if (triggers.ContainsKey(triggerId))
            {
                triggers[triggerId].Dispose();
                triggers.Remove(triggerId);
            }
        }
    }

    public class NotifyParam
    {
        public Dictionary<string, int> intDatas = new Dictionary<string, int>();

        public void Int(string key,int value)
        {
            if (!intDatas.ContainsKey(key))
                intDatas.Add(key, value);
            intDatas[key] = value;
        }

        public int Int(string key)
        {
            if (intDatas.ContainsKey(key))
                return intDatas[key];
            return -1;
        }
    }
}