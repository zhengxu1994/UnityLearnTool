using System;
using UnityEngine;
using UnityEngine.UI;
namespace ZFramework.FSM
{
    public class FSMTest : MonoBehaviour
    {
        private static int id = 0;
        private FSMManager fsmManager;
        public InputField skillUserId;
        public InputField skillTargerId;
        public InputField abnormalInput;
        public InputField campId;
        private void Start()
        {
            fsmManager = FSMManager.Inst;
        }

        private void Update()
        {
            fsmManager.Update();
        }
        //创建一个Entity
        public void CreateEntity()
        {
            FSMEntity entity = new FSMEntity();
            entity.canAttack = entity.canMove = entity.canChanting = true;
            entity.hp = 100;
            entity.atkDis = 5;
            entity.alive = true;
            entity.id = ++id;
            entity.obj = new GameObject("Entity" + entity.id);
            entity.pos = new TrueSync.TSVector2(UnityEngine.Random.Range(-100, 100),
                UnityEngine.Random.Range(-100, 100));
            entity.obj.transform.position = entity.pos.ToVector();
            entity.camp = int.Parse(campId.text);
            DecisionFSM fsm = DecisionFSM.CreateDecisionFSM(entity);
            fsmManager.AddEntity(entity);
            fsmManager.AddFSM(entity.id,fsm);
        }
        
        //选择Entity释放技能模拟 添加buff
        public void UseSkill()
        {
            int uerId = int.Parse(skillUserId.text);
            int targetId = int.Parse(skillTargerId.text);
            int abnormal = int.Parse(abnormalInput.text);
        }
        //救人
        public void SaveEntity()
        {
            int targetId = int.Parse(skillTargerId.text);
            
        }

    }
}
