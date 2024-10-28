using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookU_ClassLibrary.Models
{
    /// <summary>
    /// Our model for all Users present in the system
    /// </summary>
    [Table ("Users")]
    public class User
    {
        public User()
        {
            SentFriendRequests = new List<Friend>();
            ReceievedFriendRequests = new List<Friend>();
            PendingFriendRequests = new List<Friend>();
            UserPost = new List<Post>();
        }

        public string Password { get; set; }
        public string SEmail { get; set; }
        public string Name { get; set; }
        [Key]
        public string SNumber { get; set; }
        public string AttendingProgram { get; set; }
        public DateTime BirthDate { get; set; }
        public virtual ICollection<Friend> PendingFriendRequests { get; set; }
        public virtual ICollection<Friend> SentFriendRequests { get; set; }
        public virtual ICollection<Friend> ReceievedFriendRequests { get; set; }
        public virtual ICollection<Post> UserPost { get; set; }

        [NotMapped]
        public virtual ICollection<Friend> Friends
        {
            get
            {
                var friends = SentFriendRequests.Where(x => x.Approved).ToList();
                friends.AddRange(ReceievedFriendRequests.Where(x => x.Approved));
                return friends;
            }
        }
    }
}
