﻿using System;
using System.Collections.Generic;

namespace Pool
{
    /// <summary>
    /// 判断对象是否激活
    /// </summary>
    public interface IActivateEntity
    {
        public bool IsActive();

        public void SetActive(bool active);
    }
    /// <summary>
    /// 对象池
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PoolEntity<T> : IDisposable where T : class, IDisposable, IActivateEntity, new()
    {
        /// <summary>
        /// 数组结构可以使用栈 队列 或者 数组 
        /// </summary>
        private T[] _pool;

        private Func<T> _alloc;//初始化逻辑

        private Action<T> _recycle;//做一些数据处理

        public int ElementCount
        {
            get
            {
                return lastIndex;
            }
        }

        private bool _disposed = false;

        private int capacity = 20;

        private int lastIndex = 0;
        public PoolEntity(Func<T> alloc, Action<T> recycle, int num = 0)
        {
            _pool = new T[capacity];

            this._alloc = alloc;
            this._recycle = recycle;

            for (int i = 0; i < num; i++)
            {
                var t = alloc();
                //_pool.Enqueue(t);
                AddElement(t);
            }
        }

        ~PoolEntity()
        {
            Destroy();
        }

        public void AddElement(T t)
        {
            if (lastIndex >= _pool.Length)
            {
                var oldPool = _pool;
                _pool = new T[_pool.Length * 2];
                for (int i = 0; i < oldPool.Length; i++)
                {
                    _pool[i] = oldPool[i];
                }
                oldPool = null;
            }
            _pool[lastIndex++] = t;
        }

        public T PopElement()
        {
            lastIndex--;
            var t = _pool[lastIndex];
            _pool[lastIndex] = null;
            return t;
        }

        public T Alloc()
        {
            T t = null;
            if (lastIndex == 0)
            {
                //防止空创建方法
                if (_alloc == null)
                    t = default(T);
                else
                    t = _alloc();
            }
            else
                //抛出
                t = PopElement();
            t.SetActive(true);
            return t;
        }

        public void Recycle(T t)
        {
            //已经放回池内了
            if (!t.IsActive())
            {
                Console.WriteLine($"element is in pool,element type:{t.GetType()}");
                return;
            }
            if (_recycle != null)
                _recycle(t);

            t.SetActive(false);
            AddElement(t);
        }

        public void Destroy()
        {
            if (_disposed) return;

            if (_pool != null && _pool.Length > 0)
            {
                foreach (var item in _pool)
                {
                    item.Dispose();
                }
                _pool = null;
            }
            _pool = null;
            _disposed = true;
        }

        public void Dispose()
        {
            Destroy();
            GC.SuppressFinalize(this);
        }
    }
    ///// <summary>
    ///// 对象池
    ///// </summary>
    ///// <typeparam name="T"></typeparam>
    //public class PoolEntity<T> : IDisposable where T : class, IDisposable, IActivateEntity, new()
    //{
    //    /// <summary>
    //    /// 数组结构可以使用栈 队列 或者 数组 
    //    /// </summary>
    //    private Queue<T> _pool;

    //    private Func<T> _alloc;//初始化逻辑

    //    private Action<T> _recycle;//做一些数据处理

    //    public int ElementCount
    //    {
    //        get
    //        {
    //            return _pool.Count;
    //        }
    //    }

    //    private bool _disposed = false;

    //    private int capacity = 20;

    //    private int lastIndex = 0;
    //    public PoolEntity(Func<T> alloc, Action<T> recycle, int num = 0)
    //    {
    //        _pool = new Queue<T>();

    //        this._alloc = alloc;
    //        this._recycle = recycle;

    //        for (int i = 0; i < num; i++)
    //        {
    //            var t = alloc();
    //            _pool.Enqueue(t);
    //            //AddElement(t);
    //            //_pool.Push(t);
    //        }
    //    }

    //    ~PoolEntity()
    //    {
    //        Destroy();
    //    }

    //    //public void AddElement(T t)
    //    //{
    //    //    if (lastIndex >= _pool.Length)
    //    //    {
    //    //        var oldPool = _pool;
    //    //        _pool = new T[_pool.Length * 2];
    //    //        for (int i = 0; i < oldPool.Length; i++)
    //    //        {
    //    //            _pool[i] = oldPool[i];
    //    //        }
    //    //        oldPool = null;
    //    //    }
    //    //    _pool[lastIndex++] = t;
    //    //}

    //    //public T PopElement()
    //    //{
    //    //    lastIndex--;
    //    //    var t = _pool[lastIndex];
    //    //    _pool[lastIndex] = null;
    //    //    return t;
    //    //}

    //    public T Alloc()
    //    {
    //        T t = null;
    //        if (lastIndex == 0)
    //        {
    //            //防止空创建方法
    //            if (_alloc == null)
    //                t = default(T);
    //            else
    //                t = _alloc();
    //        }
    //        else
    //            //抛出
    //            t = _pool.Dequeue();
    //        t.SetActive(true);
    //        return t;
    //    }

    //    public void Recycle(T t)
    //    {
    //        //已经放回池内了
    //        if (!t.IsActive())
    //        {
    //            Console.WriteLine($"element is in pool,element type:{t.GetType()}");
    //            return;
    //        }
    //        if (_recycle != null)
    //            _recycle(t);

    //        t.SetActive(false);
    //        //AddElement(t);
    //        _pool.Enqueue(t);
    //    }

    //    public void Destroy()
    //    {
    //        if (_disposed) return;

    //        if (_pool != null && _pool.Count > 0)
    //        {
    //            foreach (var item in _pool)
    //            {
    //                item.Dispose();
    //            }
    //            _pool = null;
    //        }
    //        _pool = null;
    //        _disposed = true;
    //    }

    //    public void Dispose()
    //    {
    //        Destroy();
    //        GC.SuppressFinalize(this);
    //    }
    //}
}
