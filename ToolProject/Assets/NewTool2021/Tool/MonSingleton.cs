using UnityEngine;
using System.Collections;
namespace ZFramework
{
    public class MonSingleton<T>  : MonoBehaviour where T : MonSingleton<T>
    {
        protected static T instance = null;

        public static T Inst
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<T>();
                    if (FindObjectsOfType<T>().Length > 1)
                    {
                        Debug.LogError("More than 1");
                        return instance;
                    }
                    if (instance == null)
                    {
                        string instanceName = typeof(T).Name;
                        GameObject instanceGo = GameObject.Find(instanceName);
                        if (instanceGo == null)
                            instanceGo = new GameObject(instanceName);
                        instance = instanceGo.AddComponent<T>();
                        DontDestroyOnLoad(instanceGo);
                    }
                }
                return instance;
            }
        }

        protected virtual void OnDestroy()
        {
            instance = null;
        }
    }
}
