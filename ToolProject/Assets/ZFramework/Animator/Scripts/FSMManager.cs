using System;
using System.Collections.Generic;
using UnityEngine;
namespace ZFramework.FSM
{
    //Test
    public class FSMEntity
    {
        public int id;
        public bool alive;
        public bool canMove;//可以移动
        public bool canChanting;//可以释放
        public bool canAttack;//可以攻击

        public bool isControl;//受到控制

        public bool isMoving;//正在移动中
        public bool chanting;//正在施法中
        public bool attacking;//正在攻击中

        public int camp = -1;
        public Dictionary<AbnormalState, List<int>> abnormalStates = new Dictionary<AbnormalState, List<int>>();

        public int hp;

        public GameObject obj;

        public bool hasChantSkill;

        public FSMEntity atkTarget;

        public TrueSync.TSVector2 pos;

        public TrueSync.FP atkDis;

        public bool dieImmediately = false;

        public MoveOperation moveOperation;

        public void RandomMove()
        {
            
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
        Chaos
    }

    public class FSMManager : Singleton<FSMManager>
    {
        /// <summary>
        /// 移动状态下 影响内部逻辑处理的特殊状态
        /// </summary>
        public List<AbnormalState> effectMoveAbState = new List<AbnormalState>() {
            AbnormalState.RejectMove,
            AbnormalState.Chaos,
        };
        /// <summary>
        /// 影响控制的特殊状态
        /// </summary>
        public List<AbnormalState> effectControlState = new List<AbnormalState>() {
            AbnormalState.Dizzy,
        };
        /// <summary>
        /// 在攻击状态下影响内部逻辑处理的状态
        /// </summary>
        public List<AbnormalState> effectAttackState = new List<AbnormalState>() {
            AbnormalState.BeSneered,
        };
        /// <summary>
        /// 影响施法的特殊状态
        /// </summary>
        public List<AbnormalState> effectChantState = new List<AbnormalState>() {
            AbnormalState.Silent
        };

        public Dictionary<int,DecisionFSM> fsms = new Dictionary<int,DecisionFSM>();
        public Dictionary<int, FSMEntity> entities = new Dictionary<int, FSMEntity>();
        public HashSet<int> players = new HashSet<int>();
        public HashSet<int> enemies = new HashSet<int>();
        public bool pause = false;

        public void AddFSM(int id,DecisionFSM fsm)
        {
            if (!fsms.ContainsKey(id)) return;
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

        public void RemoveFSM(int id, DecisionFSM fsm)
        {
            if(fsms.ContainsKey(id))
                fsms.Remove(id);
        }

        public void Update()
        {
            if (pause) return;
            foreach (var fsm in fsms)
            {
                fsm.Value.Run();
            }
            DecisionTool.Inst.CheckUpdate(entities);
        }
    }
}
