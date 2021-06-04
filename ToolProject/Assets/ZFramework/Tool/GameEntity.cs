using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZFramework.FSM;
using ZFramework.Skill;
using ZFramework.Skill.Choose;

namespace ZFramework
{

    public class SimpleAbnormalBuff
    {
        public int id;

        int time = 0;

        public AbnormalState state;

        public SimpleAbnormalBuff(int id, int time, AbnormalState state)
        {
            this.id = id;
            this.time = time;
            this.state = state;
        }

        float tempTime = 0;
        public void Update(float deltaTime)
        {
            tempTime += deltaTime;
        }

        public bool IsOver
        {
            get { return tempTime >= time; }
        }
    }

    public class GameEntity
    {
        public int id;
        public bool alive;
        public bool nearDeath;
        public bool canMove;//可以移动
        public bool canChanting;//可以释放
        public bool canAttack;//可以攻击

        public bool isControl;//受到控制

        public bool isMoving;//正在移动中
        public bool chanting;//正在施法中
        public bool attacking;//正在攻击中

        public int atkInterval = 1;//攻击间隔

        public int damage = 10;
        public int def = 5;

        public int camp = -1;

        public TrueSync.FP searchDis = 150;
        public Dictionary<AbnormalState, List<int>> abnormalBuffs = new Dictionary<AbnormalState, List<int>>();

        public Dictionary<int, Buff> buffs = new Dictionary<int, Buff>();
        public int hp = 100;
        public int moveSpeed = 10;

        public GameObject obj;

        public bool hasChantSkill;

        public GameEntity atkTarget;

        public HashSet<GameEntity> atkerList = new HashSet<GameEntity>();

        public TrueSync.TSVector2 pos;

        public TrueSync.FP atkDis;

        public bool dieImmediately = false;

        public MoveOperation moveOperation;

        public TextMesh hpTxt;

        public EntityData data = new EntityData();

        public bool IsDizzy
        {
            get
            {
                if (abnormalBuffs.ContainsKey(AbnormalState.Dizzy)
                    && abnormalBuffs[AbnormalState.Dizzy].Count > 0)
                    return true;
                return false;
            }
        }

        public bool IsChaos
        {
            get
            {
                if (abnormalBuffs.ContainsKey(AbnormalState.Chaos)
                    && abnormalBuffs[AbnormalState.Chaos].Count > 0)
                    return true;
                return false;
            }
        }

        public bool IsBeSneered
        {
            get
            {
                if (abnormalBuffs.ContainsKey(AbnormalState.BeSneered)
                    && abnormalBuffs[AbnormalState.BeSneered].Count > 0)
                    return true;
                return false;
            }
        }

        public bool IsFear
        {
            get
            {
                if (abnormalBuffs.ContainsKey(AbnormalState.Fear)
                    && abnormalBuffs[AbnormalState.Fear].Count > 0)
                    return true;
                return false;
            }
        }

        public bool IsSilent
        {
            get
            {
                if (abnormalBuffs.ContainsKey(AbnormalState.Silent)
                    && abnormalBuffs[AbnormalState.Silent].Count > 0)
                    return true;
                return false;
            }
        }


        public void AddAbnormalState(AbnormalState state,Buff buff)
        {
            if (!abnormalBuffs.ContainsKey(state))
            {
                abnormalBuffs.Add(state, new List<int>());
            }

            abnormalBuffs[state].Add(buff.buffId);
        }

        public bool IsRejectMove
        {
            get
            {
                if (abnormalBuffs.ContainsKey(AbnormalState.RejectMove)
                    && abnormalBuffs[AbnormalState.RejectMove].Count > 0)
                    return true;
                return false;
            }
        }

        public bool IsBlood
        {
            get
            {
                if (abnormalBuffs.ContainsKey(AbnormalState.Blood)
                    && abnormalBuffs[AbnormalState.Blood].Count > 0)
                    return true;
                return false;
            }
        }

        public void RemoveAbnormalState(AbnormalState state,Buff buff)
        {
            if (!abnormalBuffs.ContainsKey(state)) return;
            if (abnormalBuffs[state].Contains(buff.buffId))
                abnormalBuffs[state].Remove(buff.buffId);
        }

        public void RandomMove()
        {

        }

        public void BeSneered()
        {
            DecisionTool.Inst.AttackTarget(atkTarget);
        }

        public void Dispose()
        {
            LogTool.LogWarning("entity 死亡，id :{0}", id);
            GameObject.Destroy(obj);
            if (atkTarget != null)
            {
                if (atkTarget.atkerList.Contains(this))
                    atkTarget.atkerList.Remove(this);
            }
            if (atkerList.Count > 0)
            {
                foreach (var atker in atkerList)
                {
                    atker.atkTarget = null;
                }
                atkerList.Clear();
            }
            if(buffs.Count > 0)
            {
                foreach (var buff in buffs)
                {
                    buff.Value.Dispose();
                }
                buffs.Clear();
            }
        }

        public void HpChange(int damage)
        {
            this.hp -= damage;
            LogTool.Log(damage.ToString());
            if (hpTxt != null)
                this.hpTxt.text = hp.ToString();
        }

        public void AddBuff(GameEntity creater,BuffData buffData)
        {
            if(buffs.ContainsKey(buffData.id))
            {
                if (buffs[buffData.id].maxStack > 1)
                {
                    //可以叠加
                }
                else
                {
                    //不可以 进行替换
                }
            }
            else
            {
                //init buff
                var buff = Buff.Create(this, creater, buffData);
                if(buff != null)
                {
                    buffs.Add(buffData.id, buff);
                }
            }
        }
    }

    public class MoveOperation
    {
        public TrueSync.TSVector2 targetPos;

        public bool force = false;
    }

    public enum AbnormalState
    {
        /// <summary>
        /// 眩晕
        /// </summary>
        Dizzy,
        /// <summary>
        /// 流血
        /// </summary>
        Blood,
        /// <summary>
        /// 沉默
        /// </summary>
        Silent,
        /// <summary>
        /// 禁足
        /// </summary>
        RejectMove,
        /// <summary>
        /// 嘲讽
        /// </summary>
        BeSneered,
        /// <summary>
        /// 混乱
        /// </summary>
        Chaos,
        /// <summary>
        /// 恐惧
        /// </summary>
        Fear,
    }


    public class EntityData
    {
        public UnitTeam team;
        public UnitRace race;
        public EntityAttr attr = new EntityAttr();
    }


    public class EntityAttr
    {
        public int maxHp;
        public int atk;
        public int speed;
        public int sex; // 0 男 1女
        public int skillRange;

        public static EntityAttr operator +(EntityAttr a, EntityAttr b)
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
}