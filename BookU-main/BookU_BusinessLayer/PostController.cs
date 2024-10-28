using BookU_ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookU_BusinessLayer
{
    public class PostController
    {
        public List<Post> GetUserPost(User user) => user.UserPost?.OrderByDescending(p => p.PublishDate).ToList();
        public List<Post> GetUserFlow(User user)
        {
            List<Post> flow = new List<Post>();
            List<User> friends = new List<User>();
            GetUserPost(user)?.ForEach(p => flow.Add(p));
            user.Friends?.ToList().ForEach(f => friends.Add(f.GetFriend(user)));
            friends?.ForEach(f => f.UserPost?.ToList().ForEach(p => flow.Add(p)));
            return flow.OrderByDescending(p => p.PublishDate).ToList();
        }

        public void AddPost(Post post)
        {
            post.Author.UserPost.Add(post);
            BookUController.Instance.Save();
        }

        public void RemovePost(Post post)
        {
            post.Author.UserPost.Remove(post);
            BookUController.Instance.Save();
        }
    }
}