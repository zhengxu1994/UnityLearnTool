using System;
using System.Collections;
using UnityEngine;
namespace ZFramework
{
    public class CoroutineHandler : MonoBehaviour
    {
        public Coroutine Coroutine;

        public bool IsCompleted;

        public bool IsRunning;

        public Coroutine StartHandler(IEnumerator rIEnum)
        {
            this.IsCompleted = false;
            this.IsRunning = true;
            this.Coroutine = this.StartCoroutine(this.StartHandler_Async(rIEnum));
            return this.Coroutine;
        }

        private IEnumerator StartHandler_Async(IEnumerator rIEnum)
        {
            yield return rIEnum;
            this.IsRunning = false;
            this.IsCompleted = true;

            yield return 0;

            CoroutineManager.Inst.Stop(this);
        }
    }
}