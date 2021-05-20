﻿using System;
using System.Collections.Generic;
using TrueSync;
using Movement;
/// <summary>
/// 技能选择接口
/// </summary>
public interface SkillChooseInterface
{
    HashSet<Skill_GameEntity> Choose(SkillChooseInfo owner, HashSet<Skill_GameEntity> old);
}

public class SkillChooseInfo
{
    public Skill_GameEntity owner;

    public TSVector2 center;

    public int skillRange;

    public FP angle;

    public TSVector2 forward;

    public int width;
}

#region Team

public class SkillChoose_TeamEnemies : SkillChooseInterface
{
    public HashSet<Skill_GameEntity> Choose(SkillChooseInfo info, HashSet<Skill_GameEntity> old)
    {
        old.RemoveWhere((entity) => {
            if (info.owner.data.team == UnitTeam.Enemy)
                return entity.data.team != UnitTeam.Friend;
            else if (info.owner.data.team == UnitTeam.Friend)
                return entity.data.team != UnitTeam.Enemy;
            else
                return false;
        });
        return old;
    }
}

public class SkillChoose_TeamFriend : SkillChooseInterface
{
    public HashSet<Skill_GameEntity> Choose(SkillChooseInfo info, HashSet<Skill_GameEntity> old)
    {
        old.RemoveWhere((entity) => {
            if (info.owner.data.team == UnitTeam.Enemy)
                return entity.data.team != UnitTeam.Enemy;
            else if (info.owner.data.team == UnitTeam.Friend)
                return entity.data.team != UnitTeam.Friend;
            else
                return entity.data.team != UnitTeam.Neutrality;
        });
        return old;
    }
}

public class SkillChoose_TeamNeutrality : SkillChooseInterface
{
    public HashSet<Skill_GameEntity> Choose(SkillChooseInfo info, HashSet<Skill_GameEntity> old)
    {
        old.RemoveWhere((entity) =>
        {
            return entity.data.team != UnitTeam.Neutrality;
        });
        return old;
    }
}
#endregion

#region Race
public class SkillChoose_RaceSolider : SkillChooseInterface
{
    public HashSet<Skill_GameEntity> Choose(SkillChooseInfo info, HashSet<Skill_GameEntity> old)
    {
        old.RemoveWhere((entity) => {
            return entity.data.race != UnitRace.Solider;
        });
        return old;
    }
}

public class SkillChoose_RaceCaptain : SkillChooseInterface
{
    public HashSet<Skill_GameEntity> Choose(SkillChooseInfo info, HashSet<Skill_GameEntity> old)
    {
        old.RemoveWhere((entity) => {
            return entity.data.race != UnitRace.Captain;
        });
        return old;
    }
}


public class SkillChoose_RaceBuilding : SkillChooseInterface
{
    public HashSet<Skill_GameEntity> Choose(SkillChooseInfo info, HashSet<Skill_GameEntity> old)
    {
        old.RemoveWhere((entity) => {
            return entity.data.race != UnitRace.Building;
        });
        return old;
    }
}

public class SkillChoose_RaceSummon : SkillChooseInterface
{
    public HashSet<Skill_GameEntity> Choose(SkillChooseInfo info, HashSet<Skill_GameEntity> old)
    {
        old.RemoveWhere((entity) => {
            return entity.data.race != UnitRace.Summon;
        });
        return old;
    }
}
#endregion

#region Area

public class SkillChoose_AreaCircle : SkillChooseInterface
{
    public HashSet<Skill_GameEntity> Choose(SkillChooseInfo info, HashSet<Skill_GameEntity> old)
    {
        old.RemoveWhere((entity) =>
        {
            if (TSVector2.DistanceSquared(info.center, entity.pixel) > info.skillRange * info.skillRange)
                return true;
            return false;
        });
        return old;
    }
}

public class SkillChoose_AreaSector : SkillChooseInterface
{
    public HashSet<Skill_GameEntity> Choose(SkillChooseInfo info, HashSet<Skill_GameEntity> old)
    {
        old.RemoveWhere((entity) =>
        {
            return !Calculater.IsPointInSector(info.center, entity.pixel, info.forward, info.angle, info.skillRange);
        });
        return old;
    }
}

public class SkillChoose_AreaRectangle : SkillChooseInterface
{
    public HashSet<Skill_GameEntity> Choose(SkillChooseInfo info, HashSet<Skill_GameEntity> old)
    {
        old.RemoveWhere((entity) =>
        {
            return !Calculater.IsPointInRectangle(info.width, info.skillRange, info.forward, info.center, entity.pixel);
        });
        return old;
    }
}
#endregion

#region Attr
public class SkillChoose_AttrMaxHp : SkillChooseInterface
{
    public HashSet<Skill_GameEntity> Choose(SkillChooseInfo info, HashSet<Skill_GameEntity> old)
    {
        var pair = old.GetEnumerator();
        int maxHp = -1;
        Skill_GameEntity target = null; 
        while (pair.MoveNext())
        {
            if(pair.Current.data.attr.maxHp > maxHp)
            {
                target = pair.Current;
                maxHp = pair.Current.data.attr.maxHp;
            }
        }
        old.Clear();
        old.Add(target);
        return old;
    }
}

public class SkillChoose_AttrMinHp : SkillChooseInterface
{
    public HashSet<Skill_GameEntity> Choose(SkillChooseInfo info, HashSet<Skill_GameEntity> old)
    {
        var pair = old.GetEnumerator();
        int minHp = int.MaxValue;
        Skill_GameEntity target = null;
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
}

public class SkillChoose_AttrMan : SkillChooseInterface
{
    public HashSet<Skill_GameEntity> Choose(SkillChooseInfo info, HashSet<Skill_GameEntity> old)
    {
        old.RemoveWhere((entity) => {
            return entity.data.attr.sex != 0;
        });
        return old;
    }
}

public class SkillChoose_AttrWoman : SkillChooseInterface
{
    public HashSet<Skill_GameEntity> Choose(SkillChooseInfo info, HashSet<Skill_GameEntity> old)
    {
        old.RemoveWhere((entity) => {
            return entity.data.attr.sex == 0;
        });
        return old;
    }
}
#endregion