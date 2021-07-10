using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using ZFramework;
public class AssetBundleDemo : MonoBehaviour
{
    //public int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        B b = new B();
        b.test();
        A a = b;
        a.test();
        ITest i = a;
        i.test();
        i = b;
        b.test();
        Debug.Log("xxxxx");

        AAA aaa = new AAA();
        //int count = 0;

        for (int j = 0; j < 10; j++)
        {
            int count = j;//这里每次进来都重新定义一个count变量 如果不重新定义那么就一致使用的是上面的int j 而int j在外部被不断的改变
            Task task = new Task(() => {
                Debug.Log(count);//打印10 闭包，最终获取的都是最后一次j++ 
            });
            task.Start();
        }
        //Debug.Log(sizeof(AAA));
        //AA aa;
        //using (aa = new AA())
        //{
        //    System.GC.Collect();
        //    System.GC.WaitForPendingFinalizers();
        //    System.GC.WaitForFullGCApproach();
        //    System.GC.WaitForFullGCComplete();

        //    aa.TestAA();
        //    aa.TestBB();
        //    aa.TestCC();
        //}
        

        //GameObject lobby = null;
        //UnityEngine.Profiling.Profiler.BeginSample("Load3");
        //for (int i = 0; i < Objects.Length; i++)
        //{
        //    lobby = Instantiate(Objects[i]) as GameObject;
        //}
        //UnityEngine.Profiling.Profiler.EndSample();

        //if(ab != null)
        //{
        //    Debug.Log("xxxx");
        //}

        //StartCoroutine(ResourceManager.DownloadAndSave("../Release/MacOS/StreamingAssets/lobby.unity3d", "lobby.unity3d", null));
        //将一个2个16位short和一个32位int 拼接称一个64位的long
        //short shortA = 1;
        //short shortB = 1;
        //int intA = 1;
        //long longA = ((long)shortA << 48) + ((long)intA << 16) + shortB;
        //Debug.Log(longA);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
interface ITest
{
    public void test();
}

public class A : ITest
{
    public virtual void test()
    {
        Debug.Log("TestA");
    }
}

public class B : A
{
    public override void test()
    {
        Debug.Log("TestB");
    }
}


public class AA : IDisposable
{
    public void TestAA()
    {
        Debug.Log("TestAA");
    }

    public void TestBB()
    {
        Debug.Log($"testB{_member}");
    }

    public virtual void TestCC()
    {
        Debug.Log("TestCC");
    }

    int _member;

    void Dispose()
    {

    }

    void IDisposable.Dispose()
    {
    }
}

public struct AAA
{
    static char a;
}