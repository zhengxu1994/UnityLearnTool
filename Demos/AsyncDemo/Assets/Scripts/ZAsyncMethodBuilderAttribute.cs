#if !SERVER
namespace System.Runtime.CompilerServices
{
    public class AsyncMethodBuilderAttribute : Attribute
    {
        public Type BuilderType
        {
            get;
        }

        public AsyncMethodBuilderAttribute(Type builderType)
        {
            BuilderType = builderType;
        }
    }
}
#endif