using System;
using System.Collections.Generic;
namespace ZFramework
{
    public static class ZTaskHelper
    {
        private class CoroutineBlocker
        {
            private int count;

            private List<ZTask> tcss = new List<ZTask>();

            public CoroutineBlocker(int count)
            {
                this.count = count;
            }

            public async ZTask WaitAsync()
            {
                --this.count;
                if (this.count < 0)
                    return;
                if(this.count == 0)
                {
                    List<ZTask> t = this.tcss;
                    this.tcss = null;
                    foreach (var ttcs in t)
                    {
                        ttcs.SetResult();
                    }
                    return;
                }
                ZTask tcs = ZTask.Create(true);
                tcss.Add(tcs);
                await tcs;
            }
        }

        public static async ZTask<bool> WaitAny<T>(ZTask<T>[] tasks,ZCancellationToken zCancellationToken = null)
        {
            if (tasks.Length == 0) return false;
            CoroutineBlocker coroutineBlocker = new CoroutineBlocker(2);
            foreach (var task in tasks)
            {
                RunOneTask(task).Coroutine();
            }

            async ZVoid RunOneTask(ZTask<T> task)
            {
                await task;
                await coroutineBlocker.WaitAsync();
            }

            await coroutineBlocker.WaitAsync();
            if (zCancellationToken == null)
                return true;

            return !zCancellationToken.IsCancel();
        }

        public static async ZTask<bool> WaitAny(ZTask[] tasks, ZCancellationToken cancellationToken = null)
        {
            if (tasks.Length == 0)
            {
                return false;
            }

            CoroutineBlocker coroutineBlocker = new CoroutineBlocker(2);

            foreach (ZTask task in tasks)
            {
                RunOneTask(task).Coroutine();
            }

            async ZVoid RunOneTask(ZTask task)
            {
                await task;
                await coroutineBlocker.WaitAsync();
            }

            await coroutineBlocker.WaitAsync();

            if (cancellationToken == null)
            {
                return true;
            }

            return !cancellationToken.IsCancel();
        }

        public static async ZTask<bool> WaitAll<T>(ZTask<T>[] tasks, ZCancellationToken cancellationToken = null)
        {
            if (tasks.Length == 0)
            {
                return false;
            }

            CoroutineBlocker coroutineBlocker = new CoroutineBlocker(tasks.Length + 1);

            foreach (ZTask<T> task in tasks)
            {
                RunOneTask(task).Coroutine();
            }

            async ZVoid RunOneTask(ZTask<T> task)
            {
                await task;
                await coroutineBlocker.WaitAsync();
            }

            await coroutineBlocker.WaitAsync();

            if (cancellationToken == null)
            {
                return true;
            }

            return !cancellationToken.IsCancel();
        }

        public static async ZTask<bool> WaitAll<T>(List<ZTask<T>> tasks, ZCancellationToken cancellationToken = null)
        {
            if (tasks.Count == 0)
            {
                return false;
            }

            CoroutineBlocker coroutineBlocker = new CoroutineBlocker(tasks.Count + 1);

            foreach (ZTask<T> task in tasks)
            {
                RunOneTask(task).Coroutine();
            }

            async ZVoid RunOneTask(ZTask<T> task)
            {
                await task;
                await coroutineBlocker.WaitAsync();
            }

            await coroutineBlocker.WaitAsync();

            if (cancellationToken == null)
            {
                return true;
            }

            return !cancellationToken.IsCancel();
        }

        public static async ZTask<bool> WaitAll(ZTask[] tasks, ZCancellationToken cancellationToken = null)
        {
            if (tasks.Length == 0)
            {
                return false;
            }

            CoroutineBlocker coroutineBlocker = new CoroutineBlocker(tasks.Length + 1);

            foreach (ZTask task in tasks)
            {
                RunOneTask(task).Coroutine();
            }

            await coroutineBlocker.WaitAsync();

            async ZVoid RunOneTask(ZTask task)
            {
                await task;
                await coroutineBlocker.WaitAsync();
            }

            if (cancellationToken == null)
            {
                return true;
            }

            return !cancellationToken.IsCancel();
        }

        public static async ZTask<bool> WaitAll(List<ZTask> tasks, ZCancellationToken cancellationToken = null)
        {
            if (tasks.Count == 0)
            {
                return false;
            }

            CoroutineBlocker coroutineBlocker = new CoroutineBlocker(tasks.Count + 1);

            foreach (ZTask task in tasks)
            {
                RunOneTask(task).Coroutine();
            }

            await coroutineBlocker.WaitAsync();

            async ZVoid RunOneTask(ZTask task)
            {
                await task;
                await coroutineBlocker.WaitAsync();
            }

            if (cancellationToken == null)
            {
                return true;
            }

            return !cancellationToken.IsCancel();
        }
    }
}
