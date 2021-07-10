using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
//内联方法/属性意味着编译器接受它并用其内容替换对它的调用(确保正确的变量等)。
//这不是C#特有的。 这通常是为了提高性能
//[MethodImpl(MethodImplOptions.AggressiveInlining)]
namespace ZFramework
{
    //ICriticalNotifyCompletion 完成等待操作时计划延续的 awaiter
    //Awaiter
    [AsyncMethodBuilder(typeof(AsyncZTaskCompletedMethodBuilder))]
    public struct ZTaskCompleted : ICriticalNotifyCompletion
    {
        [DebuggerHidden]
        public ZTaskCompleted GetAwaiter()
        {
            return this;
        }

        [DebuggerHidden]
        public bool IsCompleted => true;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [DebuggerHidden]
        public void GetResult()
        {
        }

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
