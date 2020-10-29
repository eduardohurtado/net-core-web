using System;

namespace net_core_web
{
    public interface IFriendStore
    {
        // Return <-- Method(Parameters)
        Friend friendGetData(int Id);
    }
}