using BookU_ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookU_BusinessLayer
{
    public class UserController
    {
        public User GetUser(string sEmail) => BookUController.Instance.Context.Users.Find(x => x.SEmail == sEmail).FirstOrDefault();
        public IEnumerable<User> GetAllUsers() => BookUController.Instance.Context.Users.GetAll();
        public bool ValidateUser(string sEmail, string password)
        {
            if (GetUser(sEmail)?.Password == password)
                BookUController.Instance.CurrentUser = GetUser(sEmail);
            return BookUController.Instance.CurrentUser != null;
        }

        public void AddUser(User user)
        {
            BookUController.Instance.Context.Users.Add(user);
            BookUController.Instance.Save();
        }

        public void RemoveUser(User user)
        {
            BookUController.Instance.Context.Users.Remove(user);
            BookUController.Instance.Save();
        }

        public void AddFriendRequest(User user, User friendUser)
        {
            var friendRequest = new Friend()
            {
                RequestedBy = user,
                RequestedTo = friendUser,
                RequestTime = DateTime.Now,
                FriendRequestFlag = FriendRequestFlag.None
            };
            user.SentFriendRequests.Add(friendRequest);
            friendUser.ReceievedFriendRequests.Add(friendRequest);
            friendUser.PendingFriendRequests.Add(friendRequest);
            BookUController.Instance.Save();
        }

        public void HandleFriendRequest(User user, User friendUser, FriendRequestFlag requestFlag)
        {
            if (friendUser.ReceievedFriendRequests.Count > 0)
                foreach (Friend friend in friendUser.ReceievedFriendRequests)
                    if (friend.RequestedBy == user) 
                    {
                        friend.FriendRequestFlag = requestFlag;
                        user.SentFriendRequests.Where(f => f.RequestedTo == friendUser).FirstOrDefault().FriendRequestFlag = requestFlag;
                        friendUser.ReceievedFriendRequests.Where(f => f.RequestedBy == user).FirstOrDefault().FriendRequestFlag = requestFlag;
                        friendUser.PendingFriendRequests.Remove(friendUser.PendingFriendRequests.Where(f => f.RequestedBy == user).FirstOrDefault());
                    }

            if(friendUser.SentFriendRequests.Count > 0)
                foreach (Friend friend in friendUser.SentFriendRequests)
                    if(friend.RequestedTo == user)
                    {
                        friend.FriendRequestFlag = requestFlag;
                        friendUser.SentFriendRequests.Where(f => f.RequestedTo == user).FirstOrDefault().FriendRequestFlag = requestFlag;
                        user.ReceievedFriendRequests.Where(f => f.RequestedBy == friendUser).FirstOrDefault().FriendRequestFlag = requestFlag;
                        user.PendingFriendRequests.Remove(user.PendingFriendRequests.Where(f => f.RequestedBy == friendUser).FirstOrDefault());
                    }
            BookUController.Instance.Save();
        }

        public void RemoveFriend(User user, User friendUser)
        {
            Friend request = null;
            if (friendUser.ReceievedFriendRequests.Count > 0)
                foreach (Friend friend in friendUser.ReceievedFriendRequests)
                    if (friend.RequestedBy == user)
                        request = user.SentFriendRequests.Where(f => f.RequestedTo == friendUser).FirstOrDefault();
                        

            if (friendUser.SentFriendRequests.Count > 0)
                foreach (Friend friend in friendUser.SentFriendRequests)
                    if (friend.RequestedTo == user)
                    {
                        request = user.ReceievedFriendRequests.Where(f => f.RequestedBy == friendUser).FirstOrDefault();
                        User temp = user;
                        user = friendUser;
                        friendUser = temp;
                    }
                        

            if(request != null)
            {

                user.SentFriendRequests.Remove(request);
                friendUser.ReceievedFriendRequests.Remove(request);
            }
            BookUController.Instance.Save();
        }

        public void RemovePendingRequest(User sender, User receiver)
        {
            Friend request = receiver.PendingFriendRequests.Where(p => p.RequestedBy == sender).FirstOrDefault();
            receiver.PendingFriendRequests.Remove(request);
            receiver.ReceievedFriendRequests.Remove(request);
            sender.SentFriendRequests.Remove(request);
            BookUController.Instance.Save();
        }
    }
}
