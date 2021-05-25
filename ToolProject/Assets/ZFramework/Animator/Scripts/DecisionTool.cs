using System;
using System.Collections.Generic;
using TrueSync;
namespace ZFramework.FSM
{
    public class DecisionTool : Singleton<DecisionTool>
    {
        public void CheckUpdate(Dictionary<int,FSMEntity> entities)
        {
            if (entities == null || entities.Count <= 0) return;
            FSMEntity tempEntity = null;
            //Check State Condition
            foreach (var temp in entities)
            {
                tempEntity = temp.Value;
                //首先检测死亡
                if (CheckDeath(tempEntity)) continue;
                //检测控制
                if (CheckUnControl(tempEntity)) continue;
                //检测是否释放技能
                CheckChant(tempEntity);
                //判断是否可以移动
                CheckMove(tempEntity);
                //判断是否可以攻击
                CheckAttack(tempEntity);
            }
        }

        /// <summary>
        /// 死亡了都不必往后计算了
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool CheckDeath(FSMEntity entity)
        {
            if (entity.hp <= 0 && entity.alive)
            {
                entity.alive = false;
                return true;
            }
            else if (entity.hp > 0 && entity.alive == false)
            {
                entity.alive = true;
                return false;
            }
            return false;
        }

        /// <summary>
        /// 受控制 也不必往下计算
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool CheckUnControl(FSMEntity entity)
        {
            if (entity.abnormalStates.ContainsKey(AbnormalState.Dizzy) ||
                entity.abnormalStates.ContainsKey(AbnormalState.RejectMove) ||
                entity.abnormalStates.ContainsKey(AbnormalState.Chaos) ||
                entity.abnormalStates.ContainsKey(AbnormalState.BeSneered))
                entity.isControl = true;
            else
                entity.isControl = false;
            return entity.isControl;
        }

        public void CheckChant(FSMEntity entity)
        {
            entity.chanting =  entity.hasChantSkill;
            if(entity.chanting)
            {
                entity.attacking = false;
                entity.isMoving = false;
            }
        }

        public void CheckMove(FSMEntity entity)
        {
            if (entity.abnormalStates.ContainsKey(AbnormalState.RejectMove))
            {
                entity.canMove = false;
                entity.isMoving = false;
            }
            else if (entity.moveOperation != null)
            {
                entity.canMove = true;
                entity.isMoving = true;
            }
            else if(entity.moveOperation == null)
            {
                entity.isMoving = false;
            }
        }

        public void CheckAttack(FSMEntity entity)
        {
            if (entity.atkTarget != null && TSVector2.DistanceSquared(entity.pos, entity.atkTarget.pos) <= entity.atkDis * entity.atkDis
                && (entity.moveOperation == null || !entity.moveOperation.force))
            {
                //在攻击范围内 并且 没有强制移动的指令
                entity.canAttack = true;
                entity.attacking = true;
                entity.isMoving = false;
            }
            else
            {
                entity.attacking = false;
            }
        }


        public void SearchAtkTarget(FSMEntity entity)
        {

        }

        public void AttackTarget(FSMEntity entity)
        {

        }

        public void MoveToTarget(FSMEntity entity)
        {

        }
    }
}
