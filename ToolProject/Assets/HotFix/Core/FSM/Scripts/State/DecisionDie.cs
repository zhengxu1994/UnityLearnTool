using System;
using UnityEngine;
namespace ZFramework.FSM
{
    public class DecisionDie : DecisionFSMState
    {
        public DecisionDie(FSMSystem fsm, GameEntity entity) : base(fsm, entity)
        {
            stateID = StateID.DecisionDie;
        }

        public override bool Reason()
        {
            if (!base.Reason()) return false; ;
            if(entity.alive)
            {
                fsm.PerformTransId(TransId.DecisionIdle);
                return false;
            }
            if(entity.dieImmediately == false)
            {
                fsm.PerformTransId(TransId.DecisionNearDie);
                return false;
            }
            return true;
        }

        public override void Action()
        {
            //处理死亡逻辑
            //播放死亡动画
            Log.Error("这把真的挂了");
            //从列表中移除
            FSMManager.Inst.RemoveEntity(entity);
            FSMManager.Inst.RemoveFSM(entity.id,(DecisionFSM)this.fsm);
            entity.Dispose();
        }

        public override void DoBeforeLeaving()
        {
            entity.canMove = entity.canAttack = entity.canChanting = true;
        }

        public override void DoBeforeEntering()
        {
            entity.canAttack = false;
            entity.canMove = false;
            entity.canChanting = false;
            entity.attacking = false;
            entity.isMoving = false;
            entity.chanting = false;
            entity.atkTarget = null;
        }
    }
}