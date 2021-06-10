using System;
using System.Collections.Generic;
public class DictBox<K,V> : IDisposable
{
    public Dictionary<K, V> data;

    public Action<K, V> OnChange;

    public Action<K, V> OnAdd;

    public Action<K, V> OnRemove;


    ListBox<K> keys;

    public ListBox<K> Keys
    {
        get
        {
            if (keys == null)
                throw new Exception("DictBox get Keys must defined in first");
            return keys;
        }
    }

    public V GetIndex(int index)
    {
        if (keys == null)
            throw new Exception("DictBox get Keys must defined in first");
        if (keys.Count > index)
            return data[keys[index]];
        Console.WriteLine("listBox not contains by index:" + index.ToString());
        return default;
    }

    public DictBox(bool listKey = false)
    {
        data = new Dictionary<K, V>();
        if (listKey) keys = new ListBox<K>();
    }

    public void BoxEach(Action<K,V> act)
    {
        var pair = data.GetEnumerator();
        while (pair.MoveNext())
        {
            act(pair.Current.Key, pair.Current.Value);
        }
    }

    public V this[K key]
    {
        get
        {
            V ret;
            if (data.TryGetValue(key,out ret))
            {
                return ret;
            }
            Console.WriteLine("listBox not contains by index:" + key);
            return default;
        }
        set
        {
            if (data.ContainsKey(key))
            {
                data[key] = value;
                OnChange?.Invoke(key, value);
            }
            else
            {
                data.Add(key, value);
                keys?.Add(key);
                OnAdd?.Invoke(key, value);
            }
        }
    }

    public bool TryGet(K key,out V value)
    {
        return data.TryGetValue(key, out value);
    }

    public int Count
    {
        get => data.Count;
    }

    public int Length
    {
        get => data.Count;  
    }

    public IEnumerator<KeyValuePair<K,V>> Pairs()
    {
        return data.GetEnumerator();
    }

    public bool ContainKey(K key)
    {
        return data.ContainsKey(key);
    }

    public bool ContainValue(V value)
    {
        return data.ContainsValue(value);
    }

    public void Clear()
    {
        keys?.Clear();
        data.Clear();
    }

    public bool TryGetValue(K key, out V value) => data.TryGetValue(key, out value);

    public DictBox<K,V> Add(K key,V value)
    {
        if (!ContainKey(key))
            this[key] = value;
        return this;
    }

    public bool Remove(K key)
    {
        if (data.ContainsKey(key))
        {
            OnRemove?.Invoke(key, data[key]);
            keys?.Remove(key);
            return data.Remove(key);
        }
        return false;
    }

    public IEnumerator<KeyValuePair<K,V>> GetEnumerator()
    {
        return data.GetEnumerator();
    }
   
    public void Dispose()
    {
        data.Clear();
        data = null;
    }
}
