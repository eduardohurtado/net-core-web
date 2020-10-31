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
                City = "Buenaventura"
            });
            friendList.Add(new Friend()
            {
                Id = 2,
                Name = "Christian",
                Email = "lmao@gmail.com",
                City = "Cali"
            });
            friendList.Add(new Friend()
            {
                Id = 3,
                Name = "Miguel",
                Email = "rofl@gmail.com",
                City = "Bogota"
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
    }
}