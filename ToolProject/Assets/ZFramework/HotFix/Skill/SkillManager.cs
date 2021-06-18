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
        private HashSet<Skill> skills = new HashSet<Skill>();
        private HashSet<Skill> removeList = new HashSet<Skill>();
        private Dictionary<int, SummonObject> summons = new Dictionary<int, SummonObject>();
        private HashSet<int> removeSummons = new HashSet<int>();
        public void Init()
        {
            entities = GameController.Inst.entities;
        }
        //处理技能的生命循环
        //处理技能的增加与删除

        public void Update(float deltaTime)
        {
            SkillUpdate(deltaTime);
            BuffSystem.Inst.Update(deltaTime);
        }

        public void SkillUpdate(float deltaTime)
        {
            foreach (var skill in skills)
            {
                skill.Update(deltaTime);
                if(skill.IsOver)
                {
                    removeList.Add(skill);
                }
            }
            if(removeList.Count > 0)
            {
                foreach (var removeItem in removeList)
                {
                    removeItem.Dispose();
                    skills.Remove(removeItem);
                }
                removeList.Clear();
            }
        }

        public void UpdateSummon(float deltaTime)
        {
            if (summons.Count <= 0) return;
            foreach (var summon in summons)
            {
                summon.Value.Update(deltaTime);
                if (summon.Value.isOver)
                    removeSummons.Add(summon.Key);
            }
            if(removeSummons.Count > 0)
            {
                foreach (var removeId in removeSummons)
                {
                    summons.Remove(removeId);
                }
                removeSummons.Clear();
            }
        }

        public void Remove(Skill skill)
        {
            if (!skills.Contains(skill)) return;
            removeList.Add(skill);
        }

        public void Add(Skill skill)
        {
            if (skills.Contains(skill)) return;
            skills.Add(skill);
        }

        public void AddSummon(SummonObject summon)
        {
            if (summons.ContainsKey(summon.SummonId)) return;
            summons.Add(summon.SummonId, summon);
        }

        public void RemoveSummon(int summonId)
        {
            if (!summons.ContainsKey(summonId)) return;
            summons.Remove(summonId);
        }
    }
}