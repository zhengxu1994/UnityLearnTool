using System;
namespace ZFramework.Skill
{
    public abstract class EffectNode : IDisposable
    {
        protected EffectData effectData;
        protected GameEntity owner;
        protected GameEntity creater;
        public EffectNode(GameEntity owner, GameEntity creater, EffectData effectData)
        {
            this.owner = owner;
            this.creater = creater;
            this.effectData = effectData;
        }

        public static EffectNode Create(GameEntity owner, GameEntity creater, EffectData effectData)
        {
            if (effectData == null) return null;
            EffectNode effectNode = null;
            switch (effectData.id)
            {
                case 1:
                    effectNode = new BleedEffect(owner, creater, effectData);
                    break;
            }
            return effectNode;
        }

        public abstract void DoEffect(GameEntity owner, GameEntity creater);

        public void Dispose()
        {

        }
    }

    public class DamageEffect : EffectNode
    {
        public DamageEffect(GameEntity owner, GameEntity creater, EffectData effectData) : base(owner, creater, effectData)
        {

        }

        public override void DoEffect(GameEntity owner, GameEntity creater)
        {
            DamageSystem.Inst.CountDamage(new DamageParam()
            {
                attackUid = creater.id,
                defUid = owner.id,
                formulaPercent = 10000,
                formulaAbsolute = 100,
            });
        }
    }

    public class BleedEffect : EffectNode
    {
        public BleedEffect(GameEntity owner, GameEntity creater, EffectData effectData) : base(owner, creater, effectData)
        {

        }

        public override void DoEffect(GameEntity owner, GameEntity creater)
        {
            DamageSystem.Inst.CountDamage(new DamageParam()
            {
                attackUid = creater.id,
                defUid = owner.id,
                holyDamage = effectData.fixValue,
            });
        }
    }

    public class AbnormalEffect : EffectNode
    {
        protected AbnormalState abnormalState;
        public AbnormalEffect(GameEntity owner, GameEntity creater, EffectData effectData) : base(owner, creater, effectData)
        {

        }

        public override void DoEffect(GameEntity owner, GameEntity creater)
        {

        }
    }
}