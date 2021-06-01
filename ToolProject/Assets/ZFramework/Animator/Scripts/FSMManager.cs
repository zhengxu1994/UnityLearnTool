using System;
using System.Collections.Generic;
using UnityEngine;
namespace ZFramework.FSM
{
    public class FSMManager : Singleton<FSMManager>
    {
        public Dictionary<int,DecisionFSM> fsms = new Dictionary<int,DecisionFSM>();
        public Dictionary<int, GameEntity> entities = new Dictionary<int, GameEntity>();
        public HashSet<int> players = new HashSet<int>();
        public HashSet<int> enemies = new HashSet<int>();
        public bool pause = false;

        public void AddFSM(int id,DecisionFSM fsm)
        {
            if (fsms.ContainsKey(id)) return;
            fsms.Add(id, fsm);  
        }

        public void AddEntity(GameEntity entity)
        {
            if (!entities.ContainsKey(entity.id))
            {
                entities.Add(entity.id, entity);
                if (entity.camp == 1)
                    players.Add(entity.id);
                else
                    enemies.Add(entity.id);
            }
        }

        public void RemoveEntity(GameEntity entity)
        {
            if (entities.ContainsKey(entity.id))
            {
                entities.Remove(entity.id);
                if (entity.camp == 1)
                    players.Remove(entity.id);
                else
                    enemies.Remove(entity.id);
            }
        }

        private HashSet<int> removeFSMHash = new HashSet<int>();

        public void RemoveFSM(int id, DecisionFSM fsm)
        {
            if (fsms.ContainsKey(id))
                removeFSMHash.Add(id);
        }

        public void Update()
        {
            if (pause) return;
            foreach (var fsm in fsms)
            {
                fsm.Value.Run();
            }
            if(removeFSMHash.Count > 0)
            {
                foreach (var removeId in removeFSMHash)
                {
                    if (fsms.ContainsKey(removeId))
                        fsms.Remove(removeId);
                }
            }
            foreach (var entityObj in entities)
            {
                entityObj.Value.obj.transform.position
                     = entityObj.Value.pos.ToVector();
                var buffs = entityObj.Value.abnormalBuffs;
                foreach (var buffDic in buffs)
                {
                    var bufflist = buffDic.Value;
                    for (int i = 0; i < bufflist.Count; i++)
                    {
                        bufflist[i].Update(Time.deltaTime);
                        if(bufflist[i].IsOver)
                        {
                            bufflist.RemoveAt(i);
                            i--;
                        }
                    }
                }
            } 
        }
    }
}
