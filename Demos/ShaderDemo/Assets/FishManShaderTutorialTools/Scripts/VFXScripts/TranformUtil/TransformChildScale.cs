using NaughtyAttributes;
using UnityEngine;

namespace FishMan {
    public class TransformChildScale : BaseOperator {
        [Button()]
        private void UpdatePos(){
            UpdatePos(Factor);
        }
    
        private void UpdatePos(float factor){
            var count = transform.childCount;
            for (int i = 0; i < count; i++) {
                var trans = transform.GetChild(i);
                trans.localScale = new Vector3(factor,factor,factor);
            }
        }
    
        protected override void OnUpdate(float curValue){
            UpdatePos(curValue);
        }
    }
}