using UnityEngine;

namespace FishMan {
    public class AutoDestroy:MonoBehaviour {
        public float Duration;
        private float timer;

        public void Update(){
            timer += Time.deltaTime;
            if (timer > Duration) {
                Destroy(gameObject);
            }
        }
    }
}