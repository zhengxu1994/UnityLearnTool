using UnityEngine;

namespace FishMan {
    public class TransformMoveForward: BaseOperator {
        public bool IsAutoReset;

        private Vector3 StartPos;
        private void Start(){
            StartPos = transform.position;
        }

        public override void Reset(){
            _timer = 0;
            //transform.position = StartPos;
        }

        protected override void OnUpdate(float curValue){
            transform.position += curValue * Time.deltaTime * transform.forward;
            if (IsAutoReset && _timer > Duration) {
                Reset();
            }
        }
    }
}