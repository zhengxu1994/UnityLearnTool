using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZFramework;
//Task 介绍
//Task是在ThreadPool的基础上推出的，我们简单了解下ThreadPool。
//ThreadPool中有若干数量的线程，如果有任务需要处理时，会从线程池中获取一个空闲的线程来执行任务，
//任务执行完毕后线程不会销毁，而是被线程池回收以供后续任务使用。当线程池中所有的线程都在忙碌时，
//又有新任务要处理时，线程池才会新建一个线程来处理该任务，如果线程数量达到设置的最大值，任务会排队
//等待其他任务释放线程后再执行。线程池能减少线程的创建，节省开销.
//我们知道了ThreadPool的弊端：我们不能控制线程池中线程的执行顺序，也不能获取线程池内线程取消/异常/完成的通知。
//net4.0在ThreadPool的基础上推出了Task，
//Task拥有线程池的优点，同时也解决了使用线程池不易控制的弊端。
public class TestDemo : MonoBehaviour
{
    ZTask<Object> task;
    // Start is called before the first frame update
    void Start()
    {
        //异步加载一个ab包
        this.task = AsyncLoadAssetbundle("uilobby.unity3d");
        Debug.Log("start");
        task.OnCompleted(() => {
            Debug.Log("OnCompleted");
        });
    }

    //打包的ab好想有点问题 先用其他地方的ab 验证一下
    string path = "../../../ET/ET/Release/MacOS/StreamingAssets/";
    private async ZTask<Object> AsyncLoadAssetbundle(string assetName)
    {
        assetName = assetName.ToLower();
        assetName = string.Format("{0}{1}", path,assetName);
        var request = AssetBundle.LoadFromFileAsync(assetName);
        await request;
        var bundle = request.assetBundle;
        if (bundle == null)
        {
            Debug.Log("null");
            return null;
        }
        else
        {
            var request1 = bundle.LoadAllAssetsAsync();
            await request1;
            Debug.Log(request1.allAssets[0].name);
            return request1.allAssets[0];
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(!task.IsCompleted)
        {
            Debug.Log("IsCompleted");
        }
    }
}
