using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookU_ClassLibrary.Models
{
    public class Friend
    {
        [Key, Column(Order = 0)]
        public string RequestedById { get; set; }
        [Key, Column(Order = 1)]
        public string RequestedToId { get; set; }
        public virtual User RequestedBy { get; set; }
        public virtual User RequestedTo { get; set; }

        public DateTime? RequestTime { get; set; }

        public FriendRequestFlag FriendRequestFlag { get; set; }

        [NotMapped]
        public bool Approved => FriendRequestFlag == FriendRequestFlag.Approved;

        public User GetFriend(User user)
        {
            if (user != RequestedBy) return RequestedBy;
            else return RequestedTo;
        }
    }

    public enum FriendRequestFlag
    {
        None,
        Approved,
        Rejected,
        Blocked,
        Spam
    };
}
