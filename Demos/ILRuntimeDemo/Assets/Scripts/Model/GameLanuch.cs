using System.Collections;
using UnityEngine;
using System.IO;
public class GameLanuch : MonoBehaviour
{
    ILRuntime.Runtime.Enviorment.AppDomain appdomain;
    private void Start()
    {
        StartCoroutine(LoadILRuntime());
    }

    IEnumerator LoadILRuntime()
    {
        appdomain = new ILRuntime.Runtime.Enviorment.AppDomain();
#if UNITY_ANDROID
    WWW www = new WWW(Application.streamingAssetsPath + "/Hotfix.dll");
#else
        WWW www = new WWW("file:///" + Application.streamingAssetsPath + "/Hotfix.dll");
#endif
        while (!www.isDone)
            yield return null;
        if (!string.IsNullOrEmpty(www.error))
            Debug.LogError(www.error);
        byte[] dll = www.bytes;
        www.Dispose();
#if UNITY_ANDROID
    www = new WWW(Application.streamingAssetsPath + "/Hotfix.pdb");
#else
        www = new WWW("file:///" + Application.streamingAssetsPath + "/Hotfix.pdb");
#endif
        while (!www.isDone)
            yield return null;
        if (!string.IsNullOrEmpty(www.error))
            Debug.LogError(www.error);
        byte[] pdb = www.bytes;
        System.IO.MemoryStream fs = new MemoryStream(dll);
        System.IO.MemoryStream p = new MemoryStream(pdb);
        appdomain.LoadAssembly(fs, p, new ILRuntime.Mono.Cecil.Pdb.PdbReaderProvider());

        OnILRuntimeInitialized();
    }

    void OnILRuntimeInitialized()
    {
        appdomain.Invoke("Hotfix.Main", "Init", null, null);
    }

    /// <summary>
    /// 如果不需要fixupdate 那么就注释掉
    /// </summary>
    private void FixedUpdate()
    {
        UnityEngine.Profiling.Profiler.BeginSample("FixedUpdate");
        appdomain.Invoke("Hotfix.Main", "FixedUpdate", null, null);
        UnityEngine.Profiling.Profiler.EndSample();
    }

    private void Update()
    {
        UnityEngine.Profiling.Profiler.BeginSample("Update");
        appdomain.Invoke("Hotfix.Main", "Update", null, null);
        UnityEngine.Profiling.Profiler.EndSample();
    }

    private void LateUpdate()
    {
        UnityEngine.Profiling.Profiler.BeginSample("LateUpdate");
        appdomain.Invoke("Hotfix.Main", "LateUpdate", null, null);
        UnityEngine.Profiling.Profiler.EndSample();
    }
}
