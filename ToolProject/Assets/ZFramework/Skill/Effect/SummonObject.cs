using System;
using ZFramework.Skill.Choose;
using TrueSync;
using UnityEngine;
namespace ZFramework.Skill
{
    public class SummonObject : LiveUpdate
    {
        private GameEntity owner;

        private GameEntity creater;

        private SummonData summonData;

        public TSVector2 pos;

        public TSVector2 forward;

        private FP liveTime;

        private FP tempLive;

        private GameObject obj;

        public bool isOver
        {
            get
            {
                return tempLive >= liveTime;
            }
        }
        public SummonObject(GameEntity owner,GameEntity creater,SummonData data,SkillChooseInfo chooseInfo)
        {
            this.owner = owner;
            this.creater = creater;
            this.summonData = data;
            pos = chooseInfo.center;
            forward = chooseInfo.forward;
            obj = new GameObject("SummonObj");
            obj.transform.position = pos.ToVector();
            obj.transform.rotation = Quaternion.FromToRotation(Vector3.right, forward.ToVector());
        }

        public void Update(float deltaTime)
        {
            tempLive += deltaTime;
        }

        public void Dispose()
        {

        }
    }
}