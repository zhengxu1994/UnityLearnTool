using UnityEditor;
using UnityEngine;

namespace Skill
{
    public enum BattleEvent
    {
        Inited,
        /// <summary>
        /// 抬手
        /// </summary>
        Raise,
        /// <summary>
        /// 暴击
        /// </summary>
        Crit,
        /// <summary>
        /// 闪避
        /// </summary>
        Dodge,
        BeforeCure,
        AfterCure,
        BeforeAttack,
        AfterAttack,
        HpChange,
        NearDie,
        Die,
        KillUnit
    }

    public enum TriggerType
    {
        BeControl,
        Attr,
        CureOneHp,
        AttackSoldier,
        AttackBySex,
    }

    public class Trigger
    {
        protected TriggerSkillTrigger skillTrigger;
        protected CancelSkillTrigger cancelTrigger;
        protected Skill_GameEntity creater;
        protected Skill_GameEntity owner;
        protected TriggerType triggerType;
        protected BattleEvent eventType;
        protected int triggerId;

        public Trigger()
        {

        }

        public Trigger(Skill_GameEntity creater, Skill_GameEntity owner, BattleEvent eventType, TriggerType triggerType,
            int triggerId, TriggerSkillTrigger skillTrigger, CancelSkillTrigger cancelTrigger)
        {
            this.creater = creater;
            this.owner = owner;
            this.eventType = eventType;
            this.triggerType = triggerType;
            this.triggerId = triggerId;
            this.skillTrigger = skillTrigger;
            this.cancelTrigger = cancelTrigger;
        }

        public virtual void OnEvent(EventParam evt) { }
        

        public static Trigger Create(Skill_GameEntity creater, Skill_GameEntity owner, BattleEvent eventType, TriggerType triggerType, 
            int triggerId, TriggerSkillTrigger skillTrigger, CancelSkillTrigger cancelTrigger)
        {
            Trigger trigger = null;
            switch (triggerType)
            {
                case TriggerType.BeControl:
                    break;
                case TriggerType.Attr:
                    break;
                case TriggerType.CureOneHp:
                    break;
                case TriggerType.AttackSoldier:
                    break;
                case TriggerType.AttackBySex:
                    break;
                default:
                    trigger = new Trigger();
                    break;
            }
            return trigger;
        }
    }
}