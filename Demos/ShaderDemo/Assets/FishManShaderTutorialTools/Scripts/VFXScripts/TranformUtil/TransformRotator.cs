using UnityEngine;
using UnityEngine.Accessibility;

namespace FishMan {
    public class TransformRotator : BaseOperator {
        public Transform target;

        private void Start(){
            if (target == null) {
                target = transform;
            }
        }

        protected override void OnUpdate(float curValue){
            var deg = target.rotation.eulerAngles;
            deg.y += curValue * Time.deltaTime;
            target.eulerAngles = deg;
        }
    }
}