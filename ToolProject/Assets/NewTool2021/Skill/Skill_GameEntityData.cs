using UnityEngine;

public class Skill_GameEntityData
{
    public UnitTeam team;
    public UnitRace race;
    public EntityAttr attr;
}


public class EntityAttr
{
    public int hp;
    public int maxHp;
    public int atk;
    public int speed;
    public int sex; // 0 男 1女 

    public static EntityAttr operator+(EntityAttr a,EntityAttr b)
    {
        //TODO
        EntityAttr attr = new EntityAttr();
        return attr;
    }

    public static EntityAttr operator -(EntityAttr a, EntityAttr b)
    {
        //TODO
        EntityAttr attr = new EntityAttr();
        return attr;
    }
}