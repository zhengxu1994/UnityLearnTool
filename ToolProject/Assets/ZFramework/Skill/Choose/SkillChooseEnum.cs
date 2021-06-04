namespace ZFramework.Skill.Choose
{
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
        None,
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
        None,
        CircleArea,
        SectorArea,
        RectangleArea
    }
}