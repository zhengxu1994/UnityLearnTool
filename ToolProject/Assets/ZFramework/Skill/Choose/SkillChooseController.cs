﻿namespace ZFramework.Skill.Choose
{
    /// <summary>
    /// 技能选择控制器
    /// </summary>
    public class SkillChooseController
    {
        //选择顺序 UnitTeam --> UnitRace
        //ChooseArea --> UnitAttr 
        public SkillChooseController()
        {

        }
    }

    /// <summary>
    /// 目标队伍
    /// </summary>
    public enum UnitTeam
    {
        All,
        Enemy,
        Friend,
        Neutrality
    }
    /// <summary>
    /// 目标类型，根据目标的种族
    /// </summary>
    public enum UnitRace
    {
        All,
        Solider,
        Captain,
        Building,
        Summon,
    }

    /// <summary>
    /// 目标类型根据目标的属性
    /// </summary>
    public enum UnitAttr
    {
        Man,
        WoMan,
        Nearest,
        Farest,
        MaxAtk,
        MinAtk,
        MaxHp,
        MinHp,
        Relevance,
    }

    /// <summary>
    /// 目标根据技能范围选择
    /// </summary>
    public enum ChooseArea
    {
        CircleArea,
        SectorArea,
        RectangleArea
    }
}