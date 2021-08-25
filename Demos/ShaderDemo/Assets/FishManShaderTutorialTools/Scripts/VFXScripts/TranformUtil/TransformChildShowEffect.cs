using NaughtyAttributes;
using UnityEngine;

namespace FishMan {

    public class TransformChildShowEffect : MonoBehaviour, IReset {
        public int count;
        public float Duration;
        private bool hasShowHit;
        public GameObject effect;
        public GameObject explodeEffect;
        private float timer;
        public float delayTime;
        private bool hasShowEffect;

        [Button()]
        public void Reset(){
            timer = 0;
            hasShowHit = false;
            hasShowEffect = false;
        }

        public void ShowEffect(){
            if (effect == null) return;
            for (int i = 0; i < count; i++) {
                var go = GameObject.Instantiate(effect, transform);
            }
        }

        public void ShowHitEffect(){
            if (effect == null) return;
            var count = transform.childCount;
            for (int i = 0; i < count; i++) {
                var trans = transform.GetChild(i);
                GameObject.Instantiate(explodeEffect, trans.position, Quaternion.identity);
            }
        }

        void Update(){
            timer += Time.deltaTime;
            if (timer > delayTime) {
                if (!hasShowEffect) {
                    hasShowEffect = true;
                    ShowEffect();
                }
            }

            if (timer > Duration) {
                if (!hasShowHit) {
                    hasShowHit = true;
                    ShowHitEffect();
                }
            }
        }
    }
}