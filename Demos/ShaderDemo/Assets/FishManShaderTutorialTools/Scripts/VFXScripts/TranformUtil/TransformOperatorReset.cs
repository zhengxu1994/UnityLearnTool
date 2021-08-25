using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

namespace FishMan {
    public class TransformOperatorReset : MonoBehaviour {
        [Button()]
        public void Reset(){
            var opera = GetComponents<IReset>();
            foreach (var comp in opera) {
                comp.Reset();
            }
        }
    }

    public class ShowAllEffect : MonoBehaviour {
        
        public List<Component> allComponent = new List<Component>();

        public void Update(){
            
        }
    }
}