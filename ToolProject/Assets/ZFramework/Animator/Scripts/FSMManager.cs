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
        public List<AbnormalState> abnormalStates =new List<AbnormalState>();

        public GameObject obj;
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
