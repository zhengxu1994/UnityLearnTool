using System;
using System.Collections.Generic;

/// <summary>
/// 技能选择接口
/// </summary>
public interface SkillChooseInterface
{
    HashSet<Skill_GameEntity> Choose(HashSet<Skill_GameEntity> old);
}

#region Team

public class SkillChoose_TeamEnemies : SkillChooseInterface
{
    public HashSet<Skill_GameEntity> Choose(HashSet<Skill_GameEntity> old)
    {
        //TODO
        return old;
    }
}

public class SkillChoose_TeamFriend : SkillChooseInterface
{
    public HashSet<Skill_GameEntity> Choose(HashSet<Skill_GameEntity> old)
    {
        //TODO
        return old;
    }
}

public class SkillChoose_TeamNeutrality : SkillChooseInterface
{
    public HashSet<Skill_GameEntity> Choose(HashSet<Skill_GameEntity> old)
    {
        //TODO
        return old;
    }
}
#endregion

#region Race
public class SkillChoose_RaceSolider : SkillChooseInterface
{
    public HashSet<Skill_GameEntity> Choose(HashSet<Skill_GameEntity> old)
    {
        //TODO
        return old;
    }
}

public class SkillChoose_RaceCaptain : SkillChooseInterface
{
    public HashSet<Skill_GameEntity> Choose(HashSet<Skill_GameEntity> old)
    {
        //TODO
        return old;
    }
}


public class SkillChoose_RaceBuilding : SkillChooseInterface
{
    public HashSet<Skill_GameEntity> Choose(HashSet<Skill_GameEntity> old)
    {
        //TODO
        return old;
    }
}

public class SkillChoose_RaceSummon : SkillChooseInterface
{
    public HashSet<Skill_GameEntity> Choose(HashSet<Skill_GameEntity> old)
    {
        //TODO
        return old;
    }
}
#endregion

#region Area

public class SkillChoose_AreaCircle : SkillChooseInterface
{
    public HashSet<Skill_GameEntity> Choose(HashSet<Skill_GameEntity> old)
    {
        //TODO
        return old;
    }
}

public class SkillChoose_AreaSector : SkillChooseInterface
{
    public HashSet<Skill_GameEntity> Choose(HashSet<Skill_GameEntity> old)
    {
        //TODO
        return old;
    }
}

public class SkillChoose_AreaRectangle : SkillChooseInterface
{
    public HashSet<Skill_GameEntity> Choose(HashSet<Skill_GameEntity> old)
    {
        //TODO
        return old;
    }
}
#endregion

#region Attr
public class SkillChoose_AttrMaxHp : SkillChooseInterface
{
    public HashSet<Skill_GameEntity> Choose(HashSet<Skill_GameEntity> old)
    {
        //TODO
        return old;
    }
}

public class SkillChoose_AttrMinHp : SkillChooseInterface
{
    public HashSet<Skill_GameEntity> Choose(HashSet<Skill_GameEntity> old)
    {
        //TODO
        return old;
    }
}

public class SkillChoose_AttrMan : SkillChooseInterface
{
    public HashSet<Skill_GameEntity> Choose(HashSet<Skill_GameEntity> old)
    {
        //TODO
        return old;
    }
}

public class SkillChoose_AttrWoman : SkillChooseInterface
{
    public HashSet<Skill_GameEntity> Choose(HashSet<Skill_GameEntity> old)
    {
        //TODO
        return old;
    }
}
#endregion