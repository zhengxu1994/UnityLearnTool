using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZFramework;

public class TestDemo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //异步加载一个ab包
        var task = AsyncLoadAssetbundle("uilobby.unity3d");
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
        
    }
}
