using UnityEngine;

namespace ZFramework
{
#if !NOT_CLIENT
    public class ComponentView: MonoBehaviour
    {
        public object Component
        {
            get;
            set;
        }
    }
#endif
}