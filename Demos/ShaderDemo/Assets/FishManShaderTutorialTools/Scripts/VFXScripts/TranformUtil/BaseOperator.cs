using NaughtyAttributes;
using UnityEngine;

namespace FishMan {
    public interface IReset {
        void Reset();
    }

    public class BaseOperator : MonoBehaviour,IReset {
        public AnimationCurve Curve = new AnimationCurve();
        public float Duration;
        public float Factor;
        protected float _timer;

        [Button()]
        public virtual void Reset(){
            _timer = 0;
        }

        private void Update(){
            _timer += Time.deltaTime;
            var curValue = Curve.Evaluate(Mathf.Clamp01(_timer / Duration))  * Factor;
            OnUpdate(curValue);
        }

        protected virtual void OnUpdate(float curValue){ }
    }
}