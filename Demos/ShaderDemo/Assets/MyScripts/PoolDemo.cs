using System;
using System.Collections;
using System.Collections.Generic;
using Pool;
using UnityEngine;

public class PoolDemo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PoolManager.Inst.GetPool<Student>(() => {
            return new Student();
        }, (student) => {
            student.Free();
        }, 1000);

        Student[] sts = new Student[1000];
        UnityEngine.Profiling.Profiler.BeginSample("PoolArr");
        for (int i = 0; i < 1000; i++)
        {
            PoolManager.Inst.Alloc<Student>();
            //sts[i] = PoolManager.Inst.Alloc<Student>();
        }
        UnityEngine.Profiling.Profiler.EndSample();

        //UnityEngine.Profiling.Profiler.BeginSample("PoolArrRecycle");

        //for (int i = 0; i < sts.Length; i++)
        //{
        //    PoolManager.Inst.Recycle<Student>(sts[i]);
        //}
        //UnityEngine.Profiling.Profiler.EndSample();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
public class Student : IDisposable, IActivateEntity
{
    public string name;
    public int age;
    private bool _active = true;//是否被激活，对象池回收对象激活为false

    public void Free()
    {
        name = null;
        age = -1;
    }

    public void Dispose()
    {
        name = null;
    }

    public bool IsActive()
    {
        return _active;
    }

    public void SetActive(bool active)
    {
        this._active = active;
    }
}
