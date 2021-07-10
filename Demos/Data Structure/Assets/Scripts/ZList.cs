using System;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// 自定义List
/// </summary>
/// <typeparam name="T"></typeparam>
public class ZList<T> : IEnumerable<T>
{
    #region 变量
    private T[] array;//容器

    private int N;//数量

    private int _capacity;
    #endregion

    #region 属性
    public int Count { get { return N; } }

    /// <summary>
    /// 谨慎设置，设置的值不应该小于当前列表存放的对象数量
    /// </summary>
    public int Capacity { get { return _capacity; }
        set {
            if (value < N)
                throw new Exception("ArgumentOutOfRangeException: capacity was less than the current size.");
            if (value == N) return;
            _capacity = value;
            T[] newArr = new T[_capacity];
            for (int i = 0; i < array.Length; i++)
                newArr[i] = array[i];
            array = newArr;
        }
    }



    //这里不做安全判断错了就错了
    public T this[int index]
    {
        get
        {
            return this.array[index];
        }
        set
        {
            this.array[index] = value;
        }
    }
    #endregion

    #region 构造函数
    public ZList(int capacity)
    {
        this.Capacity = capacity;
        array = new T[Capacity];
        N = 0;
    }

    public ZList()
    {
        array = new T[10];
        Capacity = 10;
        N = 0;
    }

    public ZList(IEnumerable<T> collection)
    {
        var pair = collection.GetEnumerator();
        int _count = 0;
        while (pair.MoveNext())
        {
            _count++;
            if(_count > array.Length)
            //扩容
            {
                
            }
        }
    }
 
    #endregion

    #region 方法
    public void Add(T obj)
    {
        if(N >= array.Length)
        {

        }
    }

    public void CopyTo(Array array, int index)
    {
        throw new NotImplementedException();
    }

    public IEnumerator GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
        throw new NotImplementedException();
    }



    #endregion
}
