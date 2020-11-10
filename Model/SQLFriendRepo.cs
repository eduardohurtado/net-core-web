using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace net_core_web.Model
{
    public class SQLFriendRepo : IFriendStore
    {
        private readonly AppDbContext context;
        private List<Friend> friendList;

        public SQLFriendRepo(AppDbContext context)
        {
            this.context = context;
        }

        public Friend newFriend(Friend friend)
        {
            friend.Id = getAllFriends().Max(e => e.Id) + 1;
            context.Friends.Add(friend);
            context.SaveChanges();

            return friend;
        }

        public Friend deleteFriend(int id)
        {
            Friend friend = context.Friends.Find(31);
            // if (friend != null)
            // {
            // context.Friends.Attach(friend);
            // context.Friends.Remove(friend);
            context.Entry(friend).State = EntityState.Deleted;
            context.SaveChanges();
            // }

            return friend;
        }

        public List<Friend> getAllFriends()
        {
            friendList = context.Friends.ToList<Friend>();

            return friendList;
        }

        public Friend friendGetData(int Id)
        {
            return context.Friends.Find(Id);
        }

        public Friend modifyFriend(Friend friendModify)
        {
            var employee = context.Friends.Attach(friendModify);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();

            return friendModify;
        }
    }
}