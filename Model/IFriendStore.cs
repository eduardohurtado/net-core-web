using System;
using System.Collections.Generic;

namespace net_core_web.Model
{
    public interface IFriendStore
    {
        // Return <-- Method(Parameters)
        Friend friendGetData(int Id);
        List<Friend> getAllFriends();
        Friend newFriend(Friend friend);

        // Added CRUD methods
        Friend modifyFriend(Friend friendModify);
        Friend deleteFriend(int id);
    }
}