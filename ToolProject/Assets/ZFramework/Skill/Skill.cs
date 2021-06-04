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

    public class Skill
    {
        protected FP raiseTick = 0;

        protected FP chantTick;

        protected FP endTick = 0;

        protected FP raiseTime = 0;//抬手总时间

        protected FP chantTime = 0;//吟唱总时间

        protected FP endTime = 0;

        protected FP chantInterval = 1f;//吟唱生效间隔

        protected FP tempTime = 0;

        protected bool hasRaise = true, hasChant = true, hasEnd = true;

        protected bool canRaiseBreak, canChantBreak, canEndBreak;

        protected bool needTarget = false;

        protected GameEntity owner;

        protected SkillData skillData;

        protected HashSet<GameEntity> targets = new HashSet<GameEntity>();

        protected Dictionary<int, Buff> buffs = new Dictionary<int, Buff>();

        protected HashSet<EffectNode> effects = new HashSet<EffectNode>();

        protected HashSet<SummonObject> summons = new HashSet<SummonObject>();

        protected bool raiseOver, chantOver, endOver;

        private SkillChooseInfo chooseInfo;
        public bool IsOver
        {
            get {
                return raiseOver && chantOver && endOver;
            }
        }

        public Skill(GameEntity user,SkillData skillData)
        {
            this.owner = user;
            this.skillData = skillData;
            //是否有抬手 抬手关键帧 抬手是否创建buff或者effect 抬手过程中是否可以被打断
            hasRaise = skillData.raiseData != null;
            hasChant = skillData.chantData != null;
            hasEnd = skillData.endData != null;

            if(hasRaise)
            {
                raiseTime = skillData.raiseData.raiseTime;
                raiseTick = skillData.raiseData.raiseTick;
                canRaiseBreak = skillData.raiseData.canBreak;
            }
            //是否有吟唱 吟唱时间 吟唱间隔 吟唱作用间隔 创建的buff和effect 是否可以被打断
            if(hasChant)
            {
                chantTime = skillData.chantData.chantTime;
                chantTick = skillData.chantData.chantTick;
                chantInterval = skillData.chantData.chantInterval;
                canChantBreak = skillData.chantData.canBreak;
            }
            //是否有收招动作 收招tick 是否创建buff和effect 是否可以被打断
            if(hasEnd)
            {
                endTime = skillData.endData.endTime;
                endTick = skillData.endData.endTick;
                canEndBreak = skillData.endData.canBreak;
            }
            needTarget = skillData.needTarget;
        }

        //技能有 抬手 吟唱 结束 三个阶段
        //技能逻辑 与 特效逻辑分离
        public virtual void Use(SkillChooseInfo info)
        {
            targets = SkillChoose.GetTargets(skillData.chooseData, info, GameController.Inst.entities);
            //如果没有搜索到目标 并且 技能是需要目标才能释放的 则释放失败
            if (targets == null && needTarget)
            {
                LogTool.Log("技能需要目标，释放失败");
                return;
            }
            this.chooseInfo = info;
            //成功搜到目标  则将skill 的update加入到SkillManager的update中
            SkillManager.Inst.Add(this);
            Refresh();
        }

        public void Refresh()
        {
            tempTime = 0;
            raiseOver = !hasRaise;
            triggerRaiseTick = false;
            triggerEndTick = false;
            chantOver = !hasChant;
            endOver = !hasEnd;
        }

        public void Update(float deltaTime)
        {
            Raise();
            Chant();
            End();
            tempTime += deltaTime;
        }

        private bool triggerRaiseTick = false;
        public virtual void Raise()
        {
            if (hasRaise && !raiseOver)
            {
                if (tempTime >= raiseTime)
                {
                    //raise 结束
                    raiseOver = true;
                    LogTool.Log("技能抬手结束");
                    return;
                    //结束抬手特效等
                }
                if(tempTime  >= raiseTick && !triggerRaiseTick)
                {
                    //触发抬手tick
                    //Buff
                    LogTool.Log("技能抬手Tick");
                    if (skillData.raiseData.buffs.Count > 0)
                    {
                        foreach (var entity in targets)
                        {
                            foreach (var buffData in skillData.raiseData.buffs)
                            {
                                var buff = entity.AddBuff(owner, buffData);
                                buffs.Add(buff.buffId, buff);
                            }
                        }
                    }
                    //Effect
                    if (skillData.raiseData.effects.Count > 0)
                    {
                        foreach (var entity in targets)
                        {
                            foreach (var effectData in skillData.raiseData.effects)
                            {
                                var effect = EffectNode.Create(entity, owner, effectData);
                                effect.DoEffect(entity, owner);
                                effects.Add(effect);
                            }
                        }
                    }
                    //Summon
                    if(skillData.raiseData.summons.Count > 0)
                    {
                        foreach (var entity in targets)
                        {
                            foreach (var summonData in skillData.raiseData.summons)
                            {
                                var summon = new SummonObject(entity, owner, summonData, chooseInfo);
                                summons.Add(summon);
                            }
                        }
                    }
                    triggerRaiseTick = true;
                }
            }
        }

     
        public virtual void Chant()
        {

        }

        private bool triggerEndTick = false;
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
            targets.Clear();
            if(buffs.Count > 0)
            {
                foreach (var buff in buffs)
                {
                    if (buff.Value.disposeBySkill)
                        buff.Value.Dispose();
                }
                buffs.Clear();
            }

            if(effects.Count > 0)
            {
                foreach (var effect in effects)
                {
                    effect.Dispose();
                }
                effects.Clear();
            }

            if (summons.Count > 0)
            {
                foreach (var summon in summons)
                {
                    if (summon.disposeBySkill)
                        summon.Dispose();
                }
                summons.Clear();
            }
        }
    }

    public class ActiveSkill : Skill
    {
        public ActiveSkill(GameEntity user, SkillData skillData) : base(user, skillData)
        {

        }
    }

    public class PassiveSkill : Skill
    {
        public PassiveSkill(GameEntity user, SkillData skillData) : base(user, skillData)
        {

        }
    }
}