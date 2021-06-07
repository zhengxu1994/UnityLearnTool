using System.Collections.Generic;
namespace ZFramework.Skill.Trigger
{
    public delegate void TriggerSkillTrigger(NotifyParam evt,GameEntity target);
    public delegate void CancelSkillTrigger(NotifyParam evt, GameEntity target);
    /// <summary>
    /// Trigger管理
    /// </summary>
    public class TriggerManager : Singleton<TriggerManager>
    {
        public Dictionary<int, Trigger> triggers = new Dictionary<int, Trigger>();

        public int triggerId = 0;
        public TriggerManager()
        {
            //监听移除
            //Test
        }

        public Trigger CreateTrigger(GameEntity creater, GameEntity owner, BattleEvent eventType,
             TriggerSkillTrigger skillTrigger, CancelSkillTrigger cancelTrigger)
        {
            triggerId++;
            triggers.Add(triggerId, Trigger.Create(creater, owner, eventType, triggerId, skillTrigger, cancelTrigger));
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
}