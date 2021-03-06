using System.Collections.Generic;
using System.Linq;

namespace net_core_web.Model
{
    public class MockFriendRepo : IFriendStore
    {
        private List<Friend> friendList;

        // Constructor
        public MockFriendRepo()
        {
            friendList = new List<Friend>();
            friendList.Add(new Friend()
            {
                Id = 1,
                Name = "Edward",
                Email = "lol@gmail.com",
                City = Province.Buenaventura
            });
            friendList.Add(new Friend()
            {
                Id = 2,
                Name = "Christian",
                Email = "lmao@gmail.com",
                City = Province.Cali
            });
            friendList.Add(new Friend()
            {
                Id = 3,
                Name = "Miguel",
                Email = "rofl@gmail.com",
                City = Province.Bogota
            });
        }

        public Friend friendGetData(int Id)
        {
            return this.friendList.FirstOrDefault(e => e.Id == Id);
        }

        public List<Friend> getAllFriends()
        {
            return friendList;
        }

        public Friend newFriend(Friend friend)
        {
            friend.Id = friendList.Max(e => e.Id) + 1;
            friendList.Add(friend);
            return friend;
        }

        public Friend modifyFriend(Friend friendModify)
        {
            Friend friend = friendList.FirstOrDefault(e => e.Id == friendModify.Id);
            if (friend != null)
            {
                friend.Name = friendModify.Name;
                friend.Email = friendModify.Email;
                friend.City = friendModify.City;
            }

            return friend;
        }

        public Friend deleteFriend(int id)
        {
            Friend friend = friendList.FirstOrDefault(e => e.Id == id);
            if (friend != null)
            {
                friendList.Remove(friend);
            }

            return friend;
        }
    }
}