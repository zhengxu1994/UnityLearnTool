using System;
using ZFramework.Skill.Choose;
using TrueSync;
using UnityEngine;
namespace ZFramework.Skill
{
    public class SummonObject : LiveUpdate
    {
        public static int SummonObjectId = 0;
        private GameEntity owner;

        private GameEntity creater;

        private SummonData summonData;

        public TSVector2 pos;

        public TSVector2 forward;

        private FP liveTime;

        private FP tempLive;

        private GameObject obj;

        public bool disposeBySkill { get; private set; }

        public bool isOver
        {
            get
            {
                return tempLive >= liveTime;
            }
        }

        public int SummonId
        {
            get;
            private set;
        }
        public SummonObject(GameEntity owner,GameEntity creater,SummonData data,SkillChooseInfo chooseInfo)
        {
            this.owner = owner;
            this.creater = creater;
            this.summonData = data;
            pos = chooseInfo.center;
            forward = chooseInfo.forward;
            this.disposeBySkill = data.disposeBySkill;
            obj = new GameObject("SummonObj");
            obj.transform.position = pos.ToVector();
            obj.transform.rotation = Quaternion.FromToRotation(Vector3.right, forward.ToVector());
            SummonId = ++SummonObjectId;
        }

        public void Update(float deltaTime)
        {
            tempLive += deltaTime;
        }

        public void Dispose()
        {
            if(!disposeBySkill)
            {

            }
        }
    }
}