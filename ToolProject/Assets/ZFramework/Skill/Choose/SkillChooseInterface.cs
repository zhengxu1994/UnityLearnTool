using System;
using System.Collections.Generic;
using TrueSync;
using Movement;
namespace ZFramework.Skill.Choose
{
    public class SkillChooseInfo
    {
        public GameEntity owner;

        public TSVector2 center;

        public int skillRange;

        public FP angle;

        public TSVector2 forward;

        public int width;
    }

    public class SkillChooss {

        private static HashSet<UnitTeam> teams = new HashSet<UnitTeam>();
        private static HashSet<UnitRace> races = new HashSet<UnitRace>();
        public static HashSet<GameEntity> GetTargets(ChooseData data, SkillChooseInfo info, HashSet<GameEntity> entities)
        {
            //team 多选
            HashSet<GameEntity> targets = new HashSet<GameEntity>();
            targets.UnionWith(entities);
            if(data.team.Length != 1 && data.team[0] == (int)UnitTeam.All)
            {
                teams.Clear();
                for (int i = 0; i < data.team.Length; i++)
                {
                    teams.Add((UnitTeam)data.team[i]);
                }
                ChooseByTeam(info, targets, teams);
            }
            if (data.race.Length != 1 && data.race[0] == (int)UnitRace.All)
            {
                races.Clear();
                for (int i = 0; i < data.race.Length; i++)
                {
                    races.Add((UnitRace)data.race[i]);
                }
                ChooseByRace(info, targets, races);
            }
            ChooseArea chooseArea = (ChooseArea)data.area;
            switch (chooseArea)
            {
                case ChooseArea.CircleArea:
                    ChooseAreaCircle(info, targets);
                    break;
                case ChooseArea.RectangleArea:
                    ChooseInRectangle(info, targets);
                    break;
                case ChooseArea.SectorArea:
                    ChooseInSector(info, targets);
                    break;
            }
   
            for (int i = 0; i < data.attr.Length; i++)
            {
                var attr = (UnitAttr)data.attr[i];
                switch (attr)
                {
                    case UnitAttr.MaxHp:
                        ChooseMaxHp(info, targets);
                        break;
                    case UnitAttr.MinHp:
                        ChooseMinHp(info, targets);
                        break;
                    case UnitAttr.Man:
                        ChooseMan(info, targets);
                        break;
                    case UnitAttr.WoMan:
                        ChooseWoman(info, targets);
                        break;
                }
            }
            return targets;
        }

        public static HashSet<GameEntity> ChooseByTeam(SkillChooseInfo info, HashSet<GameEntity> old,HashSet<UnitTeam> teams)
        {
            old.RemoveWhere((entity) =>
            {
                if (teams.Contains(entity.data.team))
                    return false;
                return true;
            });
            return old;
        }

        public static HashSet<GameEntity> ChooseByRace(SkillChooseInfo info, HashSet<GameEntity> old,HashSet<UnitRace> races)
        {
            old.RemoveWhere((entity) =>
            {
                if (races.Contains(entity.data.race))
                    return false;
                return true;
            });
            return old;
        }


        public static HashSet<GameEntity> ChooseAreaCircle(SkillChooseInfo info, HashSet<GameEntity> old)
        {
            old.RemoveWhere((entity) =>
            {
                if (TSVector2.DistanceSquared(info.center, entity.pos) > info.skillRange * info.skillRange)
                    return true;
                return false;
            });
            return old;
        }

        public static HashSet<GameEntity> ChooseInSector(SkillChooseInfo info, HashSet<GameEntity> old)
        {
            old.RemoveWhere((entity) =>
            {
                return !Calculater.IsPointInSector(info.center, entity.pos, info.forward, info.angle, info.skillRange);
            });
            return old;
        }

        public static HashSet<GameEntity> ChooseInRectangle(SkillChooseInfo info, HashSet<GameEntity> old)
        {
            old.RemoveWhere((entity) =>
            {
                return !Calculater.IsPointInRectangle(info.width, info.skillRange, info.forward, info.center, entity.pos);
            });
            return old;
        }

        public static HashSet<GameEntity> ChooseMaxHp(SkillChooseInfo info, HashSet<GameEntity> old)
        {
            var pair = old.GetEnumerator();
            int maxHp = -1;
            GameEntity target = null;
            while (pair.MoveNext())
            {
                if (pair.Current.data.attr.maxHp > maxHp)
                {
                    target = pair.Current;
                    maxHp = pair.Current.data.attr.maxHp;
                }
            }
            old.Clear();
            old.Add(target);
            return old;
        }

        public static HashSet<GameEntity> ChooseMinHp(SkillChooseInfo info, HashSet<GameEntity> old)
        {
            var pair = old.GetEnumerator();
            int minHp = int.MaxValue;
            GameEntity target = null;
            while (pair.MoveNext())
            {
                if (pair.Current.data.attr.maxHp < minHp)
                {
                    target = pair.Current;
                    minHp = pair.Current.data.attr.maxHp;
                }
            }
            old.Clear();
            old.Add(target);
            return old;
        }

        public static HashSet<GameEntity> ChooseMan(SkillChooseInfo info, HashSet<GameEntity> old)
        {
            old.RemoveWhere((entity) =>
            {
                return entity.data.attr.sex != 0;
            });
            return old;
        }

        public static HashSet<GameEntity> ChooseWoman(SkillChooseInfo info, HashSet<GameEntity> old)
        {
            old.RemoveWhere((entity) =>
            {
                return entity.data.attr.sex == 0;
            });
            return old;
        }
    }

}
