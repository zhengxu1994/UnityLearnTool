using System;
using System.Collections.Generic;
using ZFramework.Skill.Choose;
using TrueSync;
using ZFramework.Skill.Trigger;

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

        private int chantTriggerCount = 0;//吟唱触发效果的次数
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
                chantTriggerCount = (int)(chantTime / chantInterval);
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
                    tempTime = 0;
                    LogTool.Log("技能抬手结束");
                    return;
                    //结束抬手特效等
                }
                if(tempTime  >= raiseTick && !triggerRaiseTick)
                {
                    //触发抬手tick
                    //Buff
                    LogTool.Log("技能抬手Tick");
                    CreateBuffAndEffectAndSummons(skillData.raiseData);
                    triggerRaiseTick = true;
                }
            }
        }

        private int nowChantTriggerCount = 0;
        public virtual void Chant()
        {
            //计算结束时间 触发间隔
            if(hasChant && !chantOver)
            {
                if(nowChantTriggerCount >= chantTriggerCount)
                {
                    chantOver = true;
                    tempTime = 0;
                    LogTool.Log("技能吟唱结束");
                    return;
                }
                else if (tempTime >= chantInterval && tempTime >= chantTick)
                {
                    tempTime = 0;
                    nowChantTriggerCount++;
                    //触发效果
                    CreateBuffAndEffectAndSummons(skillData.chantData);
                }
            }
        }

        private bool triggerEndTick = false;
        public virtual void End()
        {
            if (hasEnd && !endOver)
            {
                if (tempTime >= endTime)
                {
                    //raise 结束
                    endOver = true;
                    tempTime = 0;
                    LogTool.Log("技能收招结束");
                    return;
                    //结束抬手特效等
                }
                if (tempTime >= endTick && !triggerEndTick)
                {
                    //触发抬手tick
                    //Buff
                    LogTool.Log("技能收招Tick");
                    CreateBuffAndEffectAndSummons(skillData.endData);
                    triggerEndTick = true;
                }
            }
        }

        public virtual void ForceBreak(GameEntity breaker)
        {
            //清空当前数据，推送打断消息
        }

        protected void CreateBuffAndEffectAndSummons(EffectsData data)
        {
            if (data.buffs.Count > 0)
            {
                foreach (var entity in targets)
                {
                    foreach (var buffData in data.buffs)
                    {
                        var buff = entity.AddBuff(owner, buffData);
                        buffs.Add(buff.buffId, buff);
                    }
                }
            }
            //Effect
            if (data.effects.Count > 0)
            {
                foreach (var entity in targets)
                {
                    foreach (var effectData in data.effects)
                    {
                        var effect = EffectNode.Create(entity, owner, effectData);
                        effect.DoEffect(entity, owner);
                        effects.Add(effect);
                    }
                }
            }
            //Summon
            if (data.summons.Count > 0)
            {
                foreach (var entity in targets)
                {
                    foreach (var summonData in data.summons)
                    {
                        var summon = new SummonObject(entity, owner, summonData, chooseInfo);
                        summons.Add(summon);
                    }
                }
            }
        }

        protected virtual bool CheckCD()
        {
            return true;
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
            //主动技能 流程 判断检测 -- 黑屏特效---正式触发 --- 抬手 -- 吟唱 -- 收招 --数据释放
        }
    }

    public class PassiveSkill : Skill
    {
        TriggerData triggerData;
       

        public PassiveSkill(GameEntity user, SkillData skillData) : base(user, skillData)
        {
            //被动 通过Trigger去触发 同样需要检测
            this.triggerData = skillData.triggerData;
            if(triggerData == null)
            {
                LogTool.LogError("Trigger Info is null");
                return;
            }

            targets.Add(owner);    
            CreateBuffAndEffectAndSummons(skillData.passiveData);
        }

    }
}