using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Skill
{
    public delegate void TriggerSkillTrigger();
    public delegate void CancelSkillTrigger();
    /// <summary>
    /// Trigger管理
    /// </summary>
    public class TriggerManager
    {
        public Dictionary<int, Trigger> trigger = new Dictionary<int, Trigger>();

        public int triggerId = 0;
        public TriggerManager()
        {
            //监听移除
        }

        public Trigger CreateTrigger()
        {
            return null;
        }
        
    }

    public class EventParam
    {

    }
}