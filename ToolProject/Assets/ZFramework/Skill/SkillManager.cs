using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ZFramework.Skill
{
    /// <summary>
    /// 技能的管理
    /// </summary>
    public class SkillManager : Singleton<SkillManager>
    {
        private HashSet<GameEntity> entities;

        public void Init()
        {
            entities = GameController.Inst.entities;
        }
        //处理技能的生命循环
        //处理技能的增加与删除

        public void Update(float deltaTime)
        {
            BuffSystem.Inst.Update(deltaTime);
        }

        public void Remove(int instId)
        {

        }

        public void Add()
        {

        }
    }
}