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

    public class Trigger
    {
        protected TriggerSkillTrigger skillTrigger;
        protected CancelSkillTrigger cancelTrigger;
        protected GameEntity creater;
        protected GameEntity owner;
        protected BattleEvent eventType;
        protected int triggerId;


        public Trigger(GameEntity creater, GameEntity owner, BattleEvent eventType,
            int triggerId, TriggerSkillTrigger skillTrigger, CancelSkillTrigger cancelTrigger)
        {
            this.creater = creater;
            this.owner = owner;
            this.eventType = eventType;
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

        public static Trigger Create(GameEntity creater, GameEntity owner, BattleEvent eventType, 
            int triggerId, TriggerSkillTrigger skillTrigger, CancelSkillTrigger cancelTrigger)
        {
            Trigger trigger = null;
            switch (eventType)
            {
                case BattleEvent.BeforeAttack:
                    trigger = new Trigger_BeforeAttack(creater, owner, eventType, triggerId, skillTrigger, cancelTrigger);
                    break;
                default:
                    trigger = new Trigger(creater,owner,eventType,triggerId,skillTrigger,cancelTrigger);
                    break;
            }
            return trigger;
        }
    }

    public class Trigger_BeforeAttack : Trigger
    {
        public Trigger_BeforeAttack(GameEntity creater, GameEntity owner, BattleEvent eventType, int triggerId, TriggerSkillTrigger skillTrigger, CancelSkillTrigger cancelTrigger) :
            base(creater, owner, eventType, triggerId, skillTrigger, cancelTrigger)
        {

        }

        public override void OnEvent(NotifyParam evt)
        {
            int attackUid = evt.Int("AttackUid");
            if (attackUid == owner.id)
                skillTrigger(evt, owner);
        }
    }

    public class Trigger_OnNearDeath : Trigger
    {
        public int count;
        private int tempCount = 0;
        public Trigger_OnNearDeath(GameEntity creater, GameEntity owner, BattleEvent eventType, int triggerId, TriggerSkillTrigger skillTrigger, CancelSkillTrigger cancelTrigger) : base(creater, owner, eventType, triggerId, skillTrigger, cancelTrigger)
        {
            //Test
            count = 2;
        }

        public override void OnEvent(NotifyParam evt)
        {
            if(evt.Int(UnStr.definerId) == owner.id && tempCount <= count)
            {
                skillTrigger(evt, owner);
            }
        }
    }
}