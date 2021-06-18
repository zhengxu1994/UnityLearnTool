using System;

namespace ZFramework
{
    public class ResponseTypeAttribute: BaseAttribute
    {
        public Type Type { get; }

        public ResponseTypeAttribute(Type type)
        {
            this.Type = type;
        }
    }
}