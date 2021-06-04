﻿using System;
using System.Collections.Generic;
namespace ZFramework.Skill
{
    [Serializable]
    public class SkillData
    {
        public SkillData() { }

        public string skillName;

        public int needMagic;

        public int cd;

        public bool isIgnoreAbnormal;

        public bool needTarget = true;

        public RaiseData raiseData;

        public ChantData chantData;

        public EndData endData;

        public ChooseData chooseData;
    }
    [Serializable]
    public class RaiseData
    {
        public string raiseAction;
        public int raiseTime;
        public int raiseTick;
        public bool canBreak;

        public List<EffectData> effects = new List<EffectData>();
        public List<BuffData> buffs = new List<BuffData>();
        public List<SummonData> summons = new List<SummonData>();
    }

    [Serializable]
    public class ChantData
    {
        public string chantAction;
        public bool actionRepeat;
        public int chantTime;
        public int chantTick;
        public int chantInterval;

        public bool hasBuff;
        public bool hasEffect;
        public bool canBreak;

        public List<EffectData> effects = new List<EffectData>();
        public List<BuffData> buffs = new List<BuffData>();
        public List<SummonData> summons = new List<SummonData>();
    }

    [Serializable]
    public class EndData
    {
        public string endAction;
        public int endTime;
        public int endTick;

        public bool hasBuff;
        public bool hasEffect;
        public bool canBreak;

        public List<EffectData> effects = new List<EffectData>();
        public List<BuffData> buffs = new List<BuffData>();
        public List<SummonData> summons = new List<SummonData>();
    }

    [Serializable]
    public class EffectData
    {
        public int id;
        public ChooseData chooseData;
        public int ratio;//比例
        public int fixValue;//数值

        public bool disposeBySkill;
    }

    [Serializable]
    public class BuffData
    {
        public int id;
        public TriggerData trigger;
        public List<int> effects = new List<int>();
        public int time;
        public int stack;
        public bool disposeBySkill;
    }
    [Serializable]
    public class SummonData
    {
        public int summonId;
        public TriggerData triggerData;
        public ChooseData chooseData;
        public int liveTime;
        public bool disposeBySkill;
        public List<EffectData> effects = new List<EffectData>();
        public List<BuffData> buffs = new List<BuffData>();
    }

    public class AdditionData
    {
        public bool canEvolve;
        public bool canOverlay;
        public int maxStack;
        public bool ignoreImmuneDamage;
    }

    [Serializable]
    public class TriggerData
    {
        public int triggerId;
    }

    [Serializable]
    public class ChooseData
    {
        public int[] team;
        public int[] race;
        public int area;
        public int[] attr;
    }
}