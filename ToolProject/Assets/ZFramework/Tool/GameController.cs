using System;
using System.Collections.Generic;
using ZFramework.Skill.Choose;

namespace ZFramework
{
    public class GameController : Singleton<GameController>
    {
        public HashSet<GameEntity> entities = new HashSet<GameEntity>();
        private Dictionary<int, GameEntity> entityDic = new Dictionary<int, GameEntity>();
        public void InitEntities()
        {
            GameEntity entity1 = new GameEntity();
            GameEntity entity2 = new GameEntity();
            GameEntity entity3 = new GameEntity();
            GameEntity entity4 = new GameEntity();
            entity1.id = 0;
            entity2.id = 1;
            entity3.id = 2;
            entity4.id = 3;

            entity1.data.team = UnitTeam.Friend;
            entity2.data.team = UnitTeam.Enemy;
            entity3.data.team = UnitTeam.Enemy;
            entity4.data.team = UnitTeam.Neutrality;

            entity1.data.race = UnitRace.Captain;
            entity2.data.race = UnitRace.Captain;
            entity3.data.race = UnitRace.Solider;
            entity4.data.race = UnitRace.Building;

            entity1.data.attr.maxHp = 100;
            entity2.data.attr.maxHp = 100;
            entity3.data.attr.maxHp = 200;
            entity4.data.attr.maxHp = 80;

            entities.Add(entity1);
            entities.Add(entity2);
            entities.Add(entity3);
            entities.Add(entity4);

            entityDic.Add(entity1.id, entity1);
            entityDic.Add(entity2.id, entity2);
            entityDic.Add(entity3.id, entity3);
            entityDic.Add(entity4.id, entity4);
        }

        public GameEntity GetEntityWithId(int id)
        {
            if (entityDic.ContainsKey(id))
                return entityDic[id];
            return null;
        }

        public void RemoveEntity(int id)
        {
            if (entityDic.ContainsKey(id))
            {
                var entity = entityDic[id];
                entityDic.Remove(id);
                entities.Remove(entity);
            }
        }

        public void RemoveEntity(GameEntity entity)
        {
            if(entityDic.ContainsKey(entity.id))
            {
                entityDic.Remove(entity.id);
                entities.Remove(entity);
            }
        }
    }

    public static class UnStr
    {
        public const string attackId = "attackId";

        public const string definerId = "definerId";

        public const string isDodge = "isDodge";

        public const string isCrit = "isCrit";

        public const string formulaPercent = "formulaPercent";

        public const string formulaAbsolute = "formulaAbsolute";

        public const string value = "value";

        public const string targetUid = "targetUid";
    }
}
