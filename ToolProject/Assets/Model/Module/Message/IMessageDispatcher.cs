using System.IO;

namespace ZFramework
{
    public interface IMessageDispatcher
    {
        void Dispatch(Session session, MemoryStream message);
    }
}