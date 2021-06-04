using System;
using System.Collections.Generic;
namespace ZFramework.Skill
{
    public class BuffSystem : Singleton<BuffSystem>
    {
        private HashSet<GameEntity> entities;

        public BuffSystem()
        {
            entities = GameController.Inst.entities;
        }

        private HashSet<int> removeList = new HashSet<int>();

        public void Update(float deltaTime)
        {
            if (entities == null || entities.Count <= 0) return;
            foreach (var entity in entities)
            {
                var buffs = entity.buffs;
                foreach (var gainBuff in buffs)
                {
                    gainBuff.Value.Update(deltaTime);
                    if(gainBuff.Value.IsOver)
                    {
                        removeList.Add(gainBuff.Key);
                    }
                }
                if (removeList.Count > 0)
                {
                    foreach (var removeBuffId in removeList)
                    {
                        var buff = buffs[removeBuffId];
                        buff.Dispose();
                        buffs.Remove(removeBuffId);
                    }
                    removeList.Clear();
                }
            }
        }
    }
}
