using System;
using System.ComponentModel;
using ProtoBuf;

namespace ZFramework
{
    public abstract class Object: ISupportInitialize, IDisposable
    {
        public Object()
        {
        }

        public virtual void BeginInit()
        {
        }

        public virtual void EndInit()
        {
        }

        public virtual void Dispose()
        {
        }
    }

    public class ProtoObject: Object
    {
    }
}