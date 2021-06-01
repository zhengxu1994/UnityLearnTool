using System;
using UnityEngine;
using TrueSync;
namespace ZFramework.FSM
{
    public class DecisionAttack : DecisionFSMState
    {
        public FP atkInterval = 1f;
        private FP count = 0;
        public DecisionAttack(FSMSystem fsm, GameEntity entity) : base(fsm, entity)
        {
            stateID = StateID.DecisionAttack;
        }

        public override bool Reason()
        {
            if (!base.Reason()) return false;
            if(!entity.alive ||entity.isControl || entity.isMoving || !entity.attacking)
            {
                fsm.PerformTransId(TransId.DecisionIdle);
                return false;
            }
            return true;
        }

        public override void Action()
        {
            count += Time.deltaTime;
            if (count >= atkInterval)
            {
                DecisionTool.Inst.AttackTarget(entity);
                count = 0;
            }
        }

        public override void DoBeforeLeaving()
        {
            LogTool.Log("离开攻击");
        }

        public override void DoBeforeEntering()
        {
            LogTool.Log("进入攻击");
        }
    }
}
