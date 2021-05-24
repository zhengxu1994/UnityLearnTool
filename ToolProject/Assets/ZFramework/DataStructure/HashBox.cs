using System.Collections;
using System.Collections.Generic;
using System;
namespace ZFrameWork
{
    /// <summary>
    /// 对hashset进行再一次的封装使用
    /// </summary>
    public class HashBox<T> : IDisposable
    {
        public Action<T> OnAdd;

        public Action<T> OnRemove;


        private HashSet<T> data = null;
        public HashBox()
        {
            data = new HashSet<T>();
        }

        public HashBox(HashSet<T> set)
        {
            data = set;
        }

        public HashBox(T[] arr)
        {
            data = new HashSet<T>(arr);
        }

        public void BoxEach(Action<T> act)
        {
            var pair = data.GetEnumerator();
            while (pair.MoveNext())
            {
                act(pair.Current);
            }
        }


        public void BoxEach(Func<T, bool> act)
        {
            var pair = data.GetEnumerator();
            while (pair.MoveNext())
            {
                if (act(pair.Current)) return;
            }
        }

        public int Count { get => data.Count; }

        public int Length { get => data.Count; }

        public IEnumerator<T> Pairs() { return data.GetEnumerator(); }

        public T GetOne()
        {
            var pair = Pairs();
            if (pair.MoveNext())
                return pair.Current;
            Console.WriteLine("HashBox not contain any value");
            return default;
        }

        public bool Contains(T value)
        {
            return data.Contains(value);
        }

        public void Clear()
        {
            data.Clear();
        }

        public void Add(T value)
        {
            if (!data.Contains(value))
            {
                data.Add(value);
                OnAdd?.Invoke(value);
            }
        }

        public bool Remove(T value)
        {
            if (data.Contains(value))
            {
                OnRemove?.Invoke(value);
                return data.Remove(value);
            }
            return false;
        }


        public void Dispose()
        {
            Clear();
        }
    }

}