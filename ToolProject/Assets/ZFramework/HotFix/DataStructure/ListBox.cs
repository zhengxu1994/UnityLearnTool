using System;
using System.Collections.Generic;
public class ListBox<T> : IDisposable
{
    public Action<T> OnAdd;

    public Action<int,T> OnChange;

    public Action<int,T> OnInsert;

    public Action<T> OnRemove;

    private List<T> data;

    public ListBox()
    {
        data = new List<T>();
    }

    public ListBox(List<T> data)
    {
        this.data = data;
    }

    public ListBox(T[] arr)
    {
        data = new List<T>(arr);
    }

    public int Count
    {
        get { if (data == null) return 0; else return data.Count; }
    }

    public int Length
    {
        get { if (data == null) return 0; else return data.Count; }
    }

    public ListBox<T> Add(T value)
    {
        data.Add(value);
        OnAdd?.Invoke(value);
        return this;
    }

    public void AddRange(ListBox<T> value)
    {
        data.AddRange(value.data);
    }


    public T this[int index]
    {
        get {
            if (data.Count > index)
                return data[index];
            else
                Console.WriteLine("ListBox not contains by index:" + index.ToString());
                return default;
        }
        set
        {
            if (data.Count > index)
            {
                data[index] = value;
                OnChange?.Invoke(index, value);
            }
        }
    }

    public void Reverse()
    {
        data.Reverse();
    }

    public void Clear()
    {
        data.Clear();
    }

    public int IndexOf(T item)
    {
        return data.IndexOf(item);
    }

    public bool Contains(T item)
    {
        return data.Contains(item);
    }

    public ListBox<T> FindAll(Predicate<T> match)
    {
        return new ListBox<T>(data.FindAll(match));
    }

    public T Find(Predicate<T> match)
    {
        return data.Find(match);
    }

    public bool Remove(T item)
    {
        OnRemove?.Invoke(item);
        return data.Remove(item);
    }

    public void RemoveAt(int index)
    {
        if (data.Count >index)
        {
            OnRemove?.Invoke(data[index]);
            data.RemoveAt(index);
        }
    }

    public void Insert(int index,T item)
    {
        data.Insert(index, item);
        OnInsert?.Invoke(index, item);
    }

    public int FindIndex(Predicate<T> match)
    {
        return data.FindIndex(match);
    }

    public int RemoveAll(Predicate<T> match)
    {
        return data.RemoveAll(match);
    }

    public void Sort(Comparison<T> comparision)
    {
        data.Sort(comparision);
    }

    public bool Exists(Predicate<T> match)
    {
        return data.Exists(match);
    }

    public void CopyTo(T[] arr,int arrayIndex)
    {
        data.CopyTo(arr, arrayIndex);
    }

    public void Push(HashSet<T> set)
    {
        var pair = set.GetEnumerator();
        while (pair.MoveNext())
        {
            data.Add(pair.Current);
            OnAdd?.Invoke(pair.Current);
        }
    }

    public void Dispose()
    {
        data.Clear();
        data = null;
    }

    public ListBox(T v1)
    {
        data = new List<T>();
        data.Add(v1);
    }
} 



