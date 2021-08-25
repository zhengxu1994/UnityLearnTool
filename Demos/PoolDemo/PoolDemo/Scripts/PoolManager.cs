using System;
using System.Collections.Generic;
namespace Pool
{
    /*
- 对象池管理类，管理对应类型的对象池，对象池的回收，获取接口调用，销毁某个对象，销毁所有对象池。
- 有实例化对象，释放对象，获取对象，回收对象功能
- 支持范型
- 对象继承IDisposable接口和实现析构函数
- 需不需要对象池使用场景类型？比如我战斗场景用的对象池在战斗结束后释放，但不会释放与战斗场景无关的对象池类型。
- 是否需要对已经pop出的对象保持追踪？防止忘记放回池内，在某个时间段（比如一场战斗结束）不管是不是在池内所有对象做释放处理。
     */
    public class PoolManager
    {
        private static PoolManager _inst;
        public static PoolManager Inst
        {
            get
            {
                if (_inst == null)
                    _inst = new PoolManager();
                return _inst;
            }
        }
        private Dictionary<Type, object> pools = new Dictionary<Type, object>();

        public int PoolCount
        {
            get {
                return pools.Count;
            }
        }

        public PoolEntity<T> GetPool<T>(Func<T> alloc,Action<T> free,int initNum = 0)where T: class,IDisposable ,new()
        {
            var type = typeof(T);
            PoolEntity<T> pool = null; 
            if (!pools.ContainsKey(type))
            {
                //init
                pool = new PoolEntity<T>(alloc, free, initNum);
                pools.Add(type, pool);
            }
            pool = pools[type] as PoolEntity<T>;
            return pool;
        }

        public T Alloc<T>() where T : class, IDisposable, new()
        {
            Type type = typeof(T);
            if (!pools.ContainsKey(type))
            {
                Console.WriteLine($"pool is null,pool type{type}");
                return default(T);
            }
            var pool = pools[type] as PoolEntity<T>;
            return pool.Alloc();
        }

        public void Free<T>(T t) where T : class, IDisposable, new()
        {
            Type type = typeof(T);
            if (!pools.ContainsKey(type))
            {
                Console.WriteLine($"pool is null,pool type{type}");
                return;
            }
            var pool = pools[type] as PoolEntity<T>;
            pool.Free(t);
        }

        public bool Destroy<T>() where T : class, IDisposable, new()
        {
            var type = typeof(T);
            if (!pools.ContainsKey(type))
                return false;
            (pools[type] as PoolEntity<T>).Destroy();
            pools.Remove(type);
            return true;
        }

        public void DestroyAll()
        {
            foreach (var pool in pools)
            {
                var dispose = pool.Value as IDisposable;
                dispose.Dispose();
            }
            pools.Clear();
        }
    }
}
