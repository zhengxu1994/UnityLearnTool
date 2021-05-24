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
        public bool canMove;
        public bool isMoving;
        public bool isControl;
        public bool chanting;
        public bool canChanting;
        public bool canAttack;
        public bool attacking;
        public Dictionary<AbnormalState, List<int>> abnormalStates = new Dictionary<AbnormalState, List<int>>();

        public int hp;

        public GameObject obj;

        public bool hasChantSkill;

        public FSMEntity atkTarget;

        public TrueSync.TSVector2 pos;

        public TrueSync.FP atkDis;

        public bool dieImmediately = false;

        public void RandomMove()
        {
            
        }
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

        public bool pause = false;

        public void AddFSM(int id,DecisionFSM fsm)
        {
            if (!fsms.ContainsKey(id)) return;
            fsms.Add(id, fsm);  
        }

        public void RemoveFSM(int id, DecisionFSM  fsm)
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
        }
    }
}
