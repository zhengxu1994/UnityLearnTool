using NaughtyAttributes;
using UnityEngine;

namespace FishMan {
    public class TransformChildLocation : BaseOperator {
        public float OffsetDeg;
        public float yOffset;
        [Button()]
        private void UpdatePos(){
            UpdatePos(Factor);
        }

        private void UpdatePos(float factor){
            var count = transform.childCount;
            for (int i = 0; i < count; i++) {
                var trans = transform.GetChild(i);
                float deg = i * Mathf.PI * 2 / count + OffsetDeg * Mathf.Deg2Rad;
                trans.localPosition = new Vector3(Mathf.Cos(deg) * factor,yOffset,Mathf.Sin(deg) * factor);
            }
        }

        protected override void OnUpdate(float curValue){
            UpdatePos(curValue);
        }
    }
}