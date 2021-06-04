using System;
using System.Collections.Generic;
namespace ZFramework.Skill
{
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
}
