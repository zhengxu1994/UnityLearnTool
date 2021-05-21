using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
namespace ZFramework
{
    public class Singleton<T> where T : Singleton<T>
    {
        protected static T instance = null;
        protected Singleton()
        {

        }

        public static T Inst
        {
            get
            {
                if (instance == null)
                {
                    instance = Activator.CreateInstance(typeof(T)) as T;
                }
                return instance;
            }
        }
    }
}
