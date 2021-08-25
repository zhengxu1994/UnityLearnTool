using NaughtyAttributes;
using UnityEngine;

namespace FishMan {
    public class TransformShowEffect : MonoBehaviour, IReset {
        public float delayTime;
        public GameObject effect;
        public Vector3 effectOffset;
        private bool hasShowHit;
        
        public float explodeDelayTime;
        public GameObject explodeEffect;
        public Vector3 explodeEffectOffset;
        private bool hasShowEffect;


        private float timer;

        [Button()]
        public void Reset(){
            timer = 0;
            hasShowHit = false;
            hasShowEffect = false;
        }

        public void ShowEffect(){
            if (effect == null) return;
            var go = GameObject.Instantiate(effect, transform.position + effectOffset, Quaternion.identity);
        }

        public void ShowHitEffect(){
            if (explodeEffect == null) return;
            GameObject.Instantiate(explodeEffect, transform.position + explodeEffectOffset, Quaternion.identity);
        }

        void Update(){
            timer += Time.deltaTime;
            if (timer > delayTime) {
                if (!hasShowEffect) {
                    hasShowEffect = true;
                    ShowEffect();
                }
            }

            if (timer > explodeDelayTime) {
                if (!hasShowHit) {
                    hasShowHit = true;
                    ShowHitEffect();
                }
            }
        }
    }
}