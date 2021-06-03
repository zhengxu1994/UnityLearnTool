using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZFramework.Skill.Choose;

namespace ZFramework.Skill
{
    public class SkillEditor : MonoBehaviour
    {

        public Transform[] ts;
        
        // Start is called before the first frame update
        void Start()
        {
            ChooseInitTest();
        }

        // Update is called once per frame
        void Update()
        {
            ChooseTest();
        }
        private GameEntity owner = null;

        HashSet<GameEntity> entities = new HashSet<GameEntity>();
        private void ChooseInitTest()
        {
            GameEntity entity1 = new GameEntity();
            owner = entity1;
            GameEntity entity2 = new GameEntity();
            GameEntity entity3 = new GameEntity();
            GameEntity entity4 = new GameEntity();
            entity1.id = 0;
            entity2.id = 1;
            entity3.id = 2;
            entity4.id = 3;

            entity1.data.team = UnitTeam.Friend;
            entity2.data.team = UnitTeam.Enemy;
            entity3.data.team = UnitTeam.Enemy;
            entity4.data.team = UnitTeam.Neutrality;

            entity1.data.race = UnitRace.Captain;
            entity2.data.race = UnitRace.Captain;
            entity3.data.race = UnitRace.Solider;
            entity4.data.race = UnitRace.Building;

            entity1.data.attr.maxHp = 100;
            entity2.data.attr.maxHp = 100;
            entity3.data.attr.maxHp = 200;
            entity4.data.attr.maxHp = 80;

            entities.Add(entity1);
            entities.Add(entity2);
            entities.Add(entity3);
            entities.Add(entity4);
        }

        private void ChooseTest()
        {
            foreach (var entity in entities)
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
                     entities);

                if (targets != null && targets.Count > 0)
                {
                    foreach (var t in targets)
                    {
                        Debug.Log(t.id);
                    }
                }
            }
        }
    }
}