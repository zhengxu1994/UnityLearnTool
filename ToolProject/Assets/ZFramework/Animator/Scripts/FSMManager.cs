using System;
using System.Collections.Generic;
using UnityEngine;
namespace ZFramework.FSM
{
    public class SimpleAbnormalBuff
    {
        public int id;

        int time = 0;

        public AbnormalState state;

        public SimpleAbnormalBuff(int id, int time ,AbnormalState state)
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


    //Test
    public class FSMEntity
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

        public int damage = 10;

        public int camp = -1;

            public TrueSync.FP searchDis = 150;
        public Dictionary<AbnormalState, List<SimpleAbnormalBuff>> abnormalBuffs = new Dictionary<AbnormalState, List<SimpleAbnormalBuff>>();
        public int hp = 100;
        public int moveSpeed = 10;

        public GameObject obj;

        public bool hasChantSkill;

        public FSMEntity atkTarget;

        public HashSet<FSMEntity> atkerList = new HashSet<FSMEntity>();

        public TrueSync.TSVector2 pos;

        public TrueSync.FP atkDis;

        public bool dieImmediately = false;

        public MoveOperation moveOperation;

        public TextMesh hpTxt;

        public bool IsDizzy {
            get {
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


        public void AddAbnormalState(SimpleAbnormalBuff buff)
        {
            if (!abnormalBuffs.ContainsKey(buff.state))
            {
                abnormalBuffs.Add(buff.state,new List<SimpleAbnormalBuff>());
            }

            abnormalBuffs[buff.state].Add(buff);
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

        public void RemoveAbnormalState(SimpleAbnormalBuff buff)
        {
            if (!abnormalBuffs.ContainsKey(buff.state)) return;
            if (abnormalBuffs[buff.state].Contains(buff))
                abnormalBuffs[buff.state].Remove(buff);
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
        }

        public void HpChange(int damage)
        {
            this.hp -= damage;
            this.hpTxt.text = hp.ToString();
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

    public class FSMManager : Singleton<FSMManager>
    {
        public Dictionary<int,DecisionFSM> fsms = new Dictionary<int,DecisionFSM>();
        public Dictionary<int, FSMEntity> entities = new Dictionary<int, FSMEntity>();
        public HashSet<int> players = new HashSet<int>();
        public HashSet<int> enemies = new HashSet<int>();
        public bool pause = false;

        public void AddFSM(int id,DecisionFSM fsm)
        {
            if (fsms.ContainsKey(id)) return;
            fsms.Add(id, fsm);  
        }

        public void AddEntity(FSMEntity entity)
        {
            if (!entities.ContainsKey(entity.id))
            {
                entities.Add(entity.id, entity);
                if (entity.camp == 1)
                    players.Add(entity.id);
                else
                    enemies.Add(entity.id);
            }
        }

        public void RemoveEntity(FSMEntity entity)
        {
            if (entities.ContainsKey(entity.id))
            {
                entities.Remove(entity.id);
                if (entity.camp == 1)
                    players.Remove(entity.id);
                else
                    enemies.Remove(entity.id);
            }
        }

        private HashSet<int> removeFSMHash = new HashSet<int>();

        public void RemoveFSM(int id, DecisionFSM fsm)
        {
            if (fsms.ContainsKey(id))
                removeFSMHash.Add(id);
        }

        public void Update()
        {
            if (pause) return;
            foreach (var fsm in fsms)
            {
                fsm.Value.Run();
            }
            if(removeFSMHash.Count > 0)
            {
                foreach (var removeId in removeFSMHash)
                {
                    if (fsms.ContainsKey(removeId))
                        fsms.Remove(removeId);
                }
            }
            foreach (var entityObj in entities)
            {
                entityObj.Value.obj.transform.position
                     = entityObj.Value.pos.ToVector();
                var buffs = entityObj.Value.abnormalBuffs;
                foreach (var buffDic in buffs)
                {
                    var bufflist = buffDic.Value;
                    for (int i = 0; i < bufflist.Count; i++)
                    {
                        bufflist[i].Update(Time.deltaTime);
                        if(bufflist[i].IsOver)
                        {
                            bufflist.RemoveAt(i);
                            i--;
                        }
                    }
                }
            } 
        }
    }
}
