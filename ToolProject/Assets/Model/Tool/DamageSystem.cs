using System;
using ZFramework.Skill.Trigger;

namespace ZFramework
{
    public class DamageSystem : Singleton<DamageSystem>
    {
        private NotifyParam evt;
        public void CountDamage(DamageParam param)
        {
            //流程
            //是否闪避
            GameEntity attacker = GameController.Inst.GetEntityWithId(param.attackUid);
            GameEntity definer = GameController.Inst.GetEntityWithId(param.defUid);
            if (!attacker.alive || !definer.alive) return;
            evt = new NotifyParam();
            evt.Int(UnStr.attackId, attacker.id);
            evt.Int(UnStr.definerId, definer.id);
            evt.Int(UnStr.formulaPercent, param.formulaPercent);
            evt.Int(UnStr.formulaAbsolute, param.formulaAbsolute);
            bool dodge = false;
            if (!param.canNotDodge)
            {
                //计算闪避
            }
            evt.Bool(UnStr.isDodge, dodge);

            //根据伤害比例和数值加成 计算伤害
            //是否暴击 暴击添加暴击加成
            EventTrigger.Inst.Trigger((int)BattleEvent.BeforeAttack, evt);
            //伤害减免
            //随机浮动 98-100之间
            //血量计算 修改
            //死亡判断
            //目前先简单计算下
            int value = attacker.damage - definer.def;
            if (param.holyDamage > 0)
                value += param.holyDamage;
            if (value > 0)
                definer.HpChange(value);
        }

        public static int PlusByWan(int value,int factor1,int factor2)
        {
            int tempValue = value;
            tempValue = tempValue * factor1 / 10000;
            tempValue = tempValue * factor2 / 10000;
            return (int)tempValue;
        }
    }

    public class DamageParam
    {
        public int attackUid;
        public int defUid;

        public int formulaPercent;
        public int formulaAbsolute;

        public int holyDamage;//神圣伤害 无视伤害 防御 不需要计算公式

        public bool canNotDodge;

        public bool isCrit;//是否必定暴击
    }
}
