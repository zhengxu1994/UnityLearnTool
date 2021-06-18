using System;
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

        public PassiveData passiveData;

        public ChooseData chooseData;

        public TriggerData triggerData;//专为被动准备，触发条件
    }
    [Serializable]
    public class EffectsData
    {
        public List<EffectData> effects = new List<EffectData>();
        public List<BuffData> buffs = new List<BuffData>();
        public List<SummonData> summons = new List<SummonData>();
    }

    [Serializable]
    public class RaiseData : EffectsData
    {
        public string raiseAction;
        public int raiseTime;
        public int raiseTick;
        public bool canBreak;
    }

    [Serializable]
    public class ChantData : EffectsData
    {
        public string chantAction;
        public bool actionRepeat;
        public int chantTime;
        public float chantTick;
        public int chantInterval;

        public bool canBreak;
    }

    [Serializable]
    public class EndData : EffectsData
    {
        public string endAction;
        public int endTime;
        public int endTick;

        public bool canBreak;
    }


    [Serializable]
    public class PassiveData : EffectsData
    {
        public string raiseAction;
        public int raiseTime;
        public int raiseTick;
        public bool canBreak;
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
        public bool canCoexit;
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

        public int triggerCond1;

        public int triggerCond2;
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