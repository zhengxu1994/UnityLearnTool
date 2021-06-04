using System;
using System.Collections.Generic;
using ZFramework.Skill.Choose;
using TrueSync;
namespace ZFramework.Skill
{
    //定义一些接口
    //编辑技能，
    //有一些技能效果编号 Effect Interface 拼接起来组成全部effect 有对应的effect数据
    //每个effect都有对用对象

    public interface LiveUpdate
    {
        void Update(float deltaTime);
    }
 
    public abstract class EffectNode : IDisposable
    {
        protected EffectData effectData;
        protected GameEntity owner;
        protected GameEntity creater;
        public EffectNode(GameEntity owner,GameEntity creater, EffectData effectData)
        {
            this.owner = owner;
            this.creater = creater;
            this.effectData = effectData;
        }

        public static EffectNode Create(GameEntity owner,GameEntity creater,EffectData effectData)
        {
            if (effectData == null) return null;
            EffectNode effectNode = null;
            switch (effectData.id)
            {
                case 1:
                    effectNode = new BleedEffect(owner,creater,effectData);
                    break;
            }
            return effectNode;
        }

        public abstract void DoEffect(GameEntity owner,GameEntity creater);

        public void Dispose()
        {

        }
    }

    public class DamageEffect : EffectNode
    {
        public DamageEffect(GameEntity owner, GameEntity creater, EffectData effectData) : base(owner,creater, effectData)
        {

        }

        public override void DoEffect(GameEntity owner, GameEntity creater)
        {
            DamageSystem.Inst.CountDamage(new DamageParam() {
                attackUid = creater.id,
                defUid = owner.id,
                formulaPercent = 10000,
                formulaAbsolute = 100,
            });
        }
    }

    public class BleedEffect : EffectNode
    {
        public BleedEffect(GameEntity owner, GameEntity creater, EffectData effectData) : base(owner,creater, effectData)
        {

        }

        public override void DoEffect(GameEntity owner, GameEntity creater)
        {
            DamageSystem.Inst.CountDamage(new DamageParam() {
                attackUid = creater.id,
                defUid = owner.id,
                holyDamage = effectData.fixValue,
            });
        }
    }

    public class AbnormalEffect : EffectNode
    {
        protected AbnormalState abnormalState;
        public AbnormalEffect(GameEntity owner, GameEntity creater, EffectData effectData) : base(owner,creater,effectData)
        {

        }

        public override void DoEffect(GameEntity owner, GameEntity creater)
        {
            
        }
    }

    public class Buff : LiveUpdate ,IDisposable
    {
        public static int initBuffId = 0;
        //配置数据
        private GameEntity owner;

        private GameEntity creater;

        private int defId;

        public int buffId { get; private set; }

        private int stack;

        public int maxStack { get; private set; }
        //buff 默认每秒生效一次
        private int effectInterval = 1;
        //effect list
        private List<EffectNode> effectNodes = new List<EffectNode>();

        private BuffData buffData;

        private float tempLive = 0;

        private float liveTime = 0;

        private float triggerInterval = 1f;//触发间隔

        private float tempTriggerTime = 1f;
        public bool IsOver
        {
            get {
                return tempLive >= liveTime;
            }
        }

        public Buff(GameEntity owner,GameEntity creater, BuffData data, int buffId)
        {
            this.owner = owner;
            this.creater = creater;
            this.defId = data.id;
            this.buffId = buffId;
            stack = 1;
            this.maxStack = data.stack;
            this.buffData = data;
            this.liveTime = data.time;
            for (int i = 0; i < buffData.effects.Count; i++)
            {
                var effectData = buffData.effects[i];
                //SkillEditor 获取数据 先测试
                EffectNode node = EffectNode.Create(owner, creater, SkillEditor.effectDatas[effectData]);
                if (node != null)
                    effectNodes.Add(node);
            }
        }

        private void InitEffect()
        {

        }

        public static Buff Create(GameEntity owner,GameEntity creater,BuffData data)
        {
            if (data == null) return null;
            Buff buff = new Buff(owner, creater, data, ++initBuffId);
            return buff;
        }

        public void Update(float deltaTime)
        {
            if (tempTriggerTime >= triggerInterval)
            {
                if (effectNodes.Count > 0)
                {
                    for (int i = 0; i < effectNodes.Count; i++)
                    {
                        effectNodes[i].DoEffect(owner, creater);
                    }
                }
                tempTriggerTime = 0;
            }
            tempLive += deltaTime;
            tempTriggerTime += deltaTime;
        }

        public void Dispose()
        {
            effectNodes.Clear();
            effectNodes = null;
        }
    }

    public class Skill
    {
        protected FP raiseTick = 0;

        protected FP[] chantTick;

        protected FP endTick = 0;

        protected bool hasRaise = true, hasChant = true, hasEnd = true;

        protected FP raiseTime = 0;//抬手总时间

        protected FP chantTime = 0;//吟唱总时间

        protected FP endTime = 0;

        protected FP tempTime = 0;
        //技能有 抬手 吟唱 结束 三个阶段
        //技能逻辑 与 特效逻辑分离

        public virtual void Update(FP deltaTime)
        {

        }

        public virtual void Raise()
        {
                
        }

        public virtual void Chant()
        {

        }

        public virtual void End()
        {

        }

        public virtual void RealUseSkillLogic()
        {

        }

        public virtual void ForceBreak()
        {

        }
         
        public virtual void Dispose()
        {

        }
    }

    public class ActiveSkill: Skill
    {

    }

    public class PassiveSkill : Skill
    {

    }
}