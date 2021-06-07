using System;
using System.Collections;
using UnityEngine;
namespace ZFramework
{
    public class CoroutineManager : Singleton<CoroutineManager>
    {
        private static GameObject mCoroutineRootObj;

        public void Initialize()
        {
            if(mCoroutineRootObj == null)
            {
                mCoroutineRootObj = new GameObject("CoroutineRoot");
                mCoroutineRootObj.transform.position = Vector3.zero;
                GameObject.DontDestroyOnLoad(mCoroutineRootObj);
            }
        }

        public CoroutineHandler StartHandler(IEnumerator rIEnum)
        {
            var rCourtineObj = new GameObject("coroutine");
            rCourtineObj.transform.SetParent(mCoroutineRootObj.transform);
            CoroutineHandler corHandler = null;
            rCourtineObj.TryGetComponent<CoroutineHandler>(out corHandler);
            if (corHandler == null)
                corHandler = rCourtineObj.AddComponent<CoroutineHandler>();
            return corHandler;
        }

        public Coroutine Start(IEnumerator rIEnum)
        {
            return StartHandler(rIEnum).Coroutine;
        }

        public void Stop(CoroutineHandler rCoroutineHandler)
        {
            if(rCoroutineHandler != null)
            {
                rCoroutineHandler.StopAllCoroutines();
                GameObject.DestroyImmediate(rCoroutineHandler.gameObject);
            }
            rCoroutineHandler.Coroutine = null;
            rCoroutineHandler = null;
        }
    }
}