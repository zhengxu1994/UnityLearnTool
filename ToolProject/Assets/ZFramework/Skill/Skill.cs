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
        void Update();
    }
 
    public abstract class EffectNode : IDisposable
    {
        public SkillChooseController chooseCtr;

        public EffectNode(SkillChooseController chooseCtr)
        {
            this.chooseCtr = chooseCtr;
        }

        public abstract void DoEffect(GameEntity owner,GameEntity creater);

        public void Dispose()
        {

        }
    }


    public class buff : LiveUpdate ,IDisposable
    {
        //配置数据
        private GameEntity owner;

        private GameEntity creater;

        private int id;

        private int buffId;
        //buff 默认每秒生效一次
        private int effectInterval = 1;
        //effect list
        public List<EffectNode> effectNodes = new List<EffectNode>();

        public buff(GameEntity owner,GameEntity creater,int id,int buffId)
        {
            this.owner = owner;
            this.creater = creater;
            this.id = id;
            this.buffId = buffId;
        }

        public void Update()
        {
            if (effectNodes.Count <= 0) return;
            for (int i = 0; i < effectNodes.Count; i++)
            {
                effectNodes[i].DoEffect(owner,creater);
            }
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