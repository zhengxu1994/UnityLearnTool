using System;
using System.Collections.Generic;

namespace Pool
{
    /// <summary>
    /// 对象池
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PoolEntity <T> : IDisposable where T: class,IDisposable, new() 
    {
        public Stack<T> pool;

        public HashSet<T> set;//主要用于检测是否重复放入池中

        private Func<T> alloc;//初始化逻辑

        private Action<T> free;//做一些数据处理

        public int ChildNum
        {
            get {
               return pool.Count;
            }
        }

        private bool disposed = false;

        public PoolEntity(Func<T> alloc,Action<T> free,int num = 0)
        {
            pool = new Stack<T>();
            set = new HashSet<T>();

            this.alloc = alloc;
            this.free = free;

            for (int i = 0; i < num; i++)
            {
                var t = alloc();
                pool.Push(t);
                set.Add(t);
            }
        }

        ~PoolEntity()
        {
            Destroy();
        }

        public T Alloc()
        {
            if(pool.Count == 0)
            {
                //防止空创建方法
                if (alloc == null)
                    return default(T);
                else
                   return alloc();
            }
            else
            {
                //抛出
                var item = pool.Pop();
                set.Remove(item);
                return item;
            }
        }

        public void Free(T t)
        {
            if (set.Contains(t))
            {
                Console.WriteLine($"element is in pool,element type:{t.GetType()}");
                return;
            }
            if (free != null)
                free(t);
            set.Add(t);
            pool.Push(t);
        }

        public void Destroy()
        {
            if (disposed) return;

            if (pool != null && pool.Count > 0)
            {
                foreach (var item in pool)
                {
                    item.Dispose();
                }
                pool.Clear();
                set.Clear();
            }
            pool = null;
            set = null;
            disposed = true;
        }

        public void Dispose()
        {
            Destroy();
            GC.SuppressFinalize(this);
        }
    }
}
