using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZFramework.Skill.Choose;
using ZFramework.Skill.Trigger;
namespace ZFramework.Skill
{
    public class SkillEditor : MonoBehaviour
    {

        public Transform[] ts;
        private Dictionary<int, BuffData> buffDatas = new Dictionary<int, BuffData>();
        //test
        public static Dictionary<int, EffectData> effectDatas = new Dictionary<int, EffectData>();
        // Start is called before the first frame update
        void Start()
        {
            ChooseInitTest();
            BuffData buffData = new BuffData();
            buffData.id = 1;
            buffData.time = 10;
            buffData.effects.Add(1);
            buffData.stack = 1;
            buffDatas.Add(buffData.id, buffData);
            EffectData effectData = new EffectData();
            effectData.id = 1;
            effectData.fixValue = 5;
            effectDatas.Add(1, effectData);
        }

        // Update is called once per frame
        void Update()
        {
            //ChooseTest();
            SkillTest();
            SkillManager.Inst.Update(Time.deltaTime);
        }
        private GameEntity owner = null;

        private void ChooseInitTest()
        {
            GameController.Inst.InitEntities();
            owner = GameController.Inst.GetEntityWithId(0);
        }

        private void SkillTest()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
               
                SkillData skillData = new SkillData();
                ChooseData chooseData = new ChooseData()
                {
                    team = new int[] { 1, 3 }
                 ,
                    race = new int[] { 2 },
                    area = 1,
                    attr = new int[] { 7 }
                };

                var skillChooseInfo = new SkillChooseInfo()
                {
                    owner = this.owner,
                    center = this.owner.pos,
                    skillRange = 400,
                };
                skillData.chooseData = chooseData;
                skillData.needTarget = true;
                skillData.needMagic = 0;
                skillData.raiseData = new RaiseData();
                skillData.raiseData.buffs.Add(buffDatas[1]);
                skillData.raiseData.effects.Add(effectDatas[1]);
                skillData.raiseData.raiseTime = 5;
                skillData.raiseData.raiseTick = 3;
                var skill = new Skill(owner, skillData);
                skill.Use(skillChooseInfo);
            }
        }

        private void ChooseTest()
        {
            foreach (var entity in GameController.Inst.entities)
            {
                entity.pos = ts[entity.id].position.ToTSVector2();
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                var targets = SkillChoose.GetTargets(new ChooseData()
                {
                    team = new int[] { 1, 3 }
                 ,
                    race = new int[] { 2 },
                    area = 1,
                    attr = new int[] { 7 }
                },
                     new SkillChooseInfo()
                     {
                         owner = this.owner,
                         center = this.owner.pos,
                         skillRange = 400,
                     },
                     GameController.Inst.entities);

                if (targets != null && targets.Count > 0)
                {
                    foreach (var t in targets)
                    {
                        Debug.Log(t.id);
                        //添加一个buff
                        t.AddBuff(owner, buffDatas[1]);
                    }
                }
            }
        }

        private void TriggerInitTest()
        {
            var trigger = Trigger.Trigger.Create(owner,owner,BattleEvent.BeforeAttack,1,
                (e,t) => {
                    Debug.Log("BeforeAttack");
                }, (e,t) => {
                    Debug.Log("BeforeAttack Cancel");
                });
        }
    
    }
}