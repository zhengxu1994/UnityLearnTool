using System;
using System.Collections.Generic;

namespace ZFramework
{
    public class OuterMessageStatisticComponent: Entity
    {
        public long LastCheckTime;
        public int MessageCountPerSec;
        public Dictionary<Type, int> MessageTypeCount = new Dictionary<Type, int>();
    }
}