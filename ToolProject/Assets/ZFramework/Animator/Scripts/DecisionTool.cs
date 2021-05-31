using System;
using System.Collections.Generic;
using TrueSync;
using UnityEngine;
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
                Check(tempEntity);
            }
        }

        public void Check(FSMEntity entity)
        {
            if (CheckDeath(entity)) return;
            //检测控制
            if (CheckUnControl(entity)) return;
            //检测是否释放技能
            CheckChant(entity);
            //判断是否可以移动
            CheckMove(entity);
            //判断是否可以攻击
            CheckAttack(entity);
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
                if(entity.atkerList.Count > 0)
                {
                    foreach (var atker in entity.atkerList)
                    {
                        if (atker.atkTarget == entity)
                            atker.atkTarget = null;
                    }
                    entity.atkerList.Clear();
                }
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
            if (entity.abnormalStates.Contains(AbnormalState.Dizzy) ||
                entity.abnormalStates.Contains(AbnormalState.RejectMove) ||
                entity.abnormalStates.Contains(AbnormalState.Chaos) ||
                entity.abnormalStates.Contains(AbnormalState.BeSneered))
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
            if (entity.abnormalStates.Contains(AbnormalState.RejectMove))
            {
                entity.canMove = false;
                entity.isMoving = false;
            }
            else if (entity.moveOperation != null || entity.atkTarget != null) 
            {
                entity.isMoving = true;
            }
            else if(entity.moveOperation == null)
            {
                entity.isMoving = false;
            }
        }

        public void CheckAttack(FSMEntity entity)
        {
            if (entity.atkTarget != null &&
                TSVector2.DistanceSquared(entity.pos, entity.atkTarget.pos) <= entity.atkDis * entity.atkDis
                && (entity.moveOperation == null
                ||!entity.moveOperation.force))
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
            //强制移动就不需要搜索目标了
            if (entity.moveOperation != null && entity.moveOperation.force) return;
            //搜索攻击目标
            int camp = entity.camp;
            var targets = camp == 1 ? FSMManager.Inst.enemies : FSMManager.Inst.players;
            if (targets.Count <= 0) return;
            //搜索最近的目标
            FSMEntity targetEntity = null;
            FP minDis = FP.MaxValue;
            foreach (var id in targets)
            {
                var tempEntity = FSMManager.Inst.entities[id];
                FP dis = TSVector2.DistanceSquared(tempEntity.pos, entity.pos);
                //视野内 活着的
                if (dis <= entity.searchDis * entity.searchDis && dis< minDis && tempEntity.alive)
                {
                    targetEntity = tempEntity;
                }
            }
            if (targetEntity == null) return;
            if(entity.atkTarget == null || entity.atkTarget != targetEntity)
            {
                if (entity.atkTarget != null)
                    entity.atkTarget.atkerList.Remove(entity);
                entity.atkTarget = targetEntity;
                entity.atkTarget.atkerList.Add(entity);
            }
        }

        public void  AttackTarget(FSMEntity entity)
        {
            if(entity.atkTarget == null || !entity.atkTarget.alive)
            {
                LogTool.LogError("攻击目标为空/必须活着");
                return;
            }
            entity.atkTarget.HpChange(entity.damage);
            LogTool.LogWarning("AttackerID:{0}", entity.id);
        }

        public void MoveToTarget(FSMEntity entity)
        {
            //移动到目标处
            TSVector2 nextPos;
            TSVector2 dir;
            TSVector2 endPos;
            //强制移动
            if (entity.moveOperation != null && entity.moveOperation.force)
            {
                dir = (entity.moveOperation.targetPos - entity.pos).normalized;
                endPos = entity.moveOperation.targetPos;
            }
            else if ((entity.atkTarget != null && entity.atkTarget.alive))
            {
                dir = (entity.atkTarget.pos - entity.pos).normalized;
                endPos = entity.atkTarget.pos;
            }
            else
            {
                return;
            }

            nextPos = entity.pos + dir * entity.moveSpeed * 0.01;
            if (TrueSync.TSVector2.Dot(endPos - entity.pos, endPos - nextPos) <= 0)
            {
                entity.pos = endPos;
                if (entity.moveOperation != null)
                    entity.moveOperation = null;
            }
            else
                entity.pos = nextPos;
        }
    }
}
