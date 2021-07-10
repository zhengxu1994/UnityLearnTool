using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security;
namespace ZFramework
{
    /// <summary>
    /// 异步完成
    /// </summary>
    public struct AsyncZTaskCompletedMethodBuilder 
    { 
        //1. static Create method
        [DebuggerHidden]
        public static AsyncZTaskCompletedMethodBuilder Create()
        {
            AsyncZTaskCompletedMethodBuilder builder = new AsyncZTaskCompletedMethodBuilder();
            return builder;
        }

        //2. TaskLike Task property(void)
        public ZTaskCompleted Task => default;

        //3, SetExtension
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [DebuggerHidden]
        public void SetExtension(Exception exception)
        {
            Debug.Print(exception.Message);
        }

        //4. SetResult
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [DebuggerHidden]
        public void SetResult()
        {

        }

        //5.AwaitOnCompleted  IAsyncStateMachine 异步状态机
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [DebuggerHidden]
        public void AwaitOnCompleted<TAwaiter,TStateMachine>(ref TAwaiter awaiter,ref TStateMachine stateMachine)
            where TAwaiter : ICriticalNotifyCompletion where  TStateMachine : IAsyncStateMachine
        {
            awaiter.OnCompleted(stateMachine.MoveNext);
        }

        //6.AwaitUnsafeOnCompleted
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [DebuggerHidden]
        [SecuritySafeCritical]
        public void AwaitUnsafeOnCompleted<TAwaiter,TStateMechine>(ref TAwaiter awaiter,ref TStateMechine stateMechine)
            where TAwaiter : ICriticalNotifyCompletion where TStateMechine : IAsyncStateMachine
        {
            awaiter.UnsafeOnCompleted(stateMechine.MoveNext);
        }

        //7. start
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [DebuggerHidden]
        public void Start<TStateMachine>(ref TStateMachine stateMachine) where TStateMachine : IAsyncStateMachine
        {
            stateMachine.MoveNext();
        }

        //8. setStateMachine
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [DebuggerHidden]
        public void SetStateMechine(IAsyncStateMachine stateMachine)
        {
        }
    }
}
