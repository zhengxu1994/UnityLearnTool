using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
namespace ZFramework.FSM
{
    public class FSMTest : MonoBehaviour
    {
        private static int id = 0;
        private static int buffId = 0;
        private FSMManager fsmManager;
        public InputField skillUserId;
        public InputField skillTargerId;
        public InputField abnormalInput;
        public InputField campId;
        public GameObject playerPrefab;
        public GameObject enemyPrefab;

        public GameEntity playerEntity = null;
        private void Start()
        {
            fsmManager = FSMManager.Inst;
        }

        private void Update()
        {
            fsmManager.Update();
            if(Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                if (playerEntity == null) return;
                var inputPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                inputPos.z = 0;
                playerEntity.moveOperation = new MoveOperation() {
                    force = true,
                    targetPos = inputPos.ToTSVector2()
                };
                LogTool.Log("Pos:{0}", inputPos);
            }
        }
        //创建一个Entity
        public void CreateEntity()
        {
            GameEntity entity = new GameEntity();
            entity.canAttack = entity.canMove = entity.canChanting = true;
            entity.hp = 100;
            entity.atkDis = 5;
            entity.alive = true;
            entity.id = ++id;
            entity.camp = int.Parse(campId.text);
            entity.obj = Instantiate(entity.camp == 1 ? playerPrefab : enemyPrefab);
            entity.hpTxt = entity.obj.GetComponentInChildren<TextMesh>();
            entity.obj.name = "Entity" + id.ToString();
            entity.pos = new TrueSync.TSVector2(UnityEngine.Random.Range(-100, 100),
                UnityEngine.Random.Range(-100, 100));
            entity.obj.transform.position = entity.pos.ToVector();
            DecisionFSM fsm = DecisionFSM.CreateDecisionFSM(entity);
            fsmManager.AddEntity(entity);
            fsmManager.AddFSM(entity.id,fsm);
            if (playerEntity == null)
                playerEntity = entity;
        }
        
        //选择Entity释放技能模拟 添加buff
        public void UseSkill()
        {
            int uerId = int.Parse(skillUserId.text);
            int targetId = int.Parse(skillTargerId.text);
            int abnormal = int.Parse(abnormalInput.text);
            var userEntity = fsmManager.entities[uerId];
            var targetEntity = fsmManager.entities[targetId];
            if (userEntity.camp == targetEntity.camp) return;
            buffId++;
            targetEntity.AddAbnormalState(new SimpleAbnormalBuff(buffId,5,(AbnormalState)abnormal));
        }
        //救人
        public void SaveEntity()
        {
            int targetId = int.Parse(skillTargerId.text);
            if (FSMManager.Inst.entities.ContainsKey(targetId))
            {
                GameEntity entity = FSMManager.Inst.entities[targetId];
                entity.HpChange(-100);
            }
        }

    }
}
