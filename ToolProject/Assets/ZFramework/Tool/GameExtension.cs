using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;

namespace ZFramework
{
    public static class Extension
    {
        public static TaskAwaiter<int> GetAwaiter(this Process process)
        {
            var tcs = new TaskCompletionSource<int>();

            process.EnableRaisingEvents = true;
            process.Exited += (s, e) => tcs.TrySetResult(process.ExitCode);

            if (process.HasExited)
                tcs.TrySetResult(process.ExitCode);

            return tcs.Task.GetAwaiter();
        }

        public static async void WrapErrors(this Task task)
        {
            await task;
        }
    }
}