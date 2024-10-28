using BookU_ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookU_BusinessLayer
{
    class TESTDATA
    {
        private readonly string admin = "admin";
        private readonly string filip = "s194346@student.hb.se";
        private readonly string emma = "s192714@student.hb.se";
        public TESTDATA()
        {
            GenerateUsers().ForEach(u => BookUController.Instance.UController.AddUser(u));
            BookUController.Instance.Context.Complete();
            List<Post> posts = GeneratePost();
            GenerateComments().ForEach(c => BookUController.Instance.CController.AddComment(c, posts.FirstOrDefault()));
            posts.ForEach(p => BookUController.Instance.PController.AddPost(p));
            GenerateFriends();
        }
        public List<User> GenerateUsers()
        {
            var Filip = new User()
            {
                SEmail = "s194346@student.hb.se",
                Password = "hejsan",
                Name = "Filip Andersson",
                SNumber = "s194346",
                BirthDate = DateTime.Parse("1996-10-20").Date,
                AttendingProgram = "Systemarkitektutbildningen",
            };
            var Admin = new User()
            {
                SEmail = "admin",
                Password = "admin",
                Name = "Admin",
                SNumber = "a1",
                BirthDate = DateTime.Parse("1996-10-20"),
                AttendingProgram = "Admin School",
            };
            var Emma = new User()
            {
                SEmail = "s192714@student.hb.se",
                Password = "hej",
                Name = "Emma Gunnarsson",
                SNumber = "s192714",
                BirthDate = DateTime.Parse("2000-03-07"),
                AttendingProgram = "Dataekonomutbildningen",
            };

            return new List<User>() { Admin, Filip, Emma };
        }
        public List<Comment> GenerateComments()
        {
            Random random = new Random();
            Comment comment = new Comment()
            {
                Author = BookUController.Instance.UController.GetUser(admin),
                PublishDate = DateTime.Now,
                CommentID = random.Next(1000),
                Text = NLipsum.Core.LipsumGenerator.Generate(4)
            };

            Comment comment1 = new Comment()
            {
                Author = BookUController.Instance.UController.GetUser(emma),
                PublishDate = DateTime.Now,
                CommentID = random.Next(1000),
                Text = NLipsum.Core.LipsumGenerator.Generate(4)
            };

            return new List<Comment>() { comment, comment1 };
        }

        public List<Post> GeneratePost()
        {
            Random random = new Random();
            Post post1 = new Post()
            {
                Author = BookUController.Instance.UController.GetUser(filip),
                PostID = random.Next(1000),
                PublishDate = DateTime.Now,
                Text = NLipsum.Core.LipsumGenerator.Generate(10),
                Comments = new List<Comment>()
            };
            Post post2 = new Post()
            {
                Author = BookUController.Instance.UController.GetUser(emma),
                PostID = random.Next(1000),
                PublishDate = DateTime.Now,
                Text = NLipsum.Core.LipsumGenerator.Generate(10),
                Comments = new List<Comment>()
            };

            Post post3 = new Post()
            {
                Author = BookUController.Instance.UController.GetUser(admin),
                PostID = random.Next(1000),
                PublishDate = DateTime.Now,
                Text = NLipsum.Core.LipsumGenerator.Generate(10), 
                Comments = new List<Comment>()
            };
            return new List<Post>() { post1, post2, post3 };
        }

        public void GenerateFriends()
        {
            User Filip = BookUController.Instance.UController.GetUser(filip);
            User Emma = BookUController.Instance.UController.GetUser(emma);
            User Admin = BookUController.Instance.UController.GetUser(admin);

            BookUController.Instance.UController.AddFriendRequest(Filip, Emma);
            BookUController.Instance.UController.AddFriendRequest(Filip, Admin);
            //BookUController.Instance.UController.AddFriendRequest(Admin, Emma);
            BookUController.Instance.UController.HandleFriendRequest(Filip, Emma, FriendRequestFlag.Approved);
            BookUController.Instance.UController.HandleFriendRequest(Filip, Admin, FriendRequestFlag.Approved);
            //BookUController.Instance.UController.HandleFriendRequest(Admin, Emma, FriendRequestFlag.Approved);
            BookUController.Instance.Context.Complete();
        }
    }
}
