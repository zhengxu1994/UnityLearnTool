using UnityEditor;
using UnityEngine;

namespace ZFramework.Skill.Trigger
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
        BeforeAttack,
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
            EventTrigger.Inst.Add((int)eventType, this, OnEvent);
        }

        public virtual void OnEvent(NotifyParam evt) { }

        public virtual void Dispose()
        {
            EventTrigger.Inst.RemoveAll(this);
        }

        public static Trigger Create(Skill_GameEntity creater, Skill_GameEntity owner, BattleEvent eventType, TriggerType triggerType, 
            int triggerId, TriggerSkillTrigger skillTrigger, CancelSkillTrigger cancelTrigger)
        {
            Trigger trigger = null;
            switch (triggerType)
            {
                case TriggerType.BeforeAttack:
                    trigger = new Trigger_BeforeAttack(creater, owner, eventType, triggerType, triggerId, skillTrigger, cancelTrigger);
                    break;
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
                    trigger = new Trigger(creater,owner,eventType,triggerType,triggerId,skillTrigger,cancelTrigger);
                    break;
            }
            return trigger;
        }
    }

    public class Trigger_BeforeAttack : Trigger
    {
        public Trigger_BeforeAttack(Skill_GameEntity creater, Skill_GameEntity owner, BattleEvent eventType, TriggerType triggerType, int triggerId, TriggerSkillTrigger skillTrigger, CancelSkillTrigger cancelTrigger) :
            base(creater, owner, eventType, triggerType, triggerId, skillTrigger, cancelTrigger)
        {

        }

        public override void OnEvent(NotifyParam evt)
        {
            int attackUid = evt.Int("AttackUid");
            if (attackUid == owner.id)
                skillTrigger(evt, owner);
        }
    }
}