using System;
using System.Collections.Generic;
using System.Linq;
using ProtoBuf;

namespace ZFramework
{
    public class ProtoObject: Object
    {
        public object Clone()
        {
            byte[] bytes = ProtobufHelper.ToBytes(this);
            return ProtobufHelper.FromBytes(this.GetType(), bytes, 0, bytes.Length);
        }
    }
}