using System;
using System.Runtime.CompilerServices;
using System.Diagnostics;
namespace ZFramework
{
    [AsyncMethodBuilder(typeof(AsyncZVoidMethodBuilder))]
    public struct ZVoid : ICriticalNotifyCompletion
    {
        [DebuggerHidden]
        public void Coroutine()
        {
        }

        [DebuggerHidden]
        public bool IsCompleted => true;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [DebuggerHidden]
        public void OnCompleted(Action continuation)
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [DebuggerHidden]
        public void UnsafeOnCompleted(Action continuation)
        {
        }
    }
}
