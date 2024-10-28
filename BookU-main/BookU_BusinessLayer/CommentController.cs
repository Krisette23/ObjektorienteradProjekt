using BookU_ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookU_BusinessLayer
{
    public class CommentController
    {
        public void AddComment(Comment comment, Post post)
        {
            post.Comments.Add(comment);
            BookUController.Instance.Save();
        }

        public void RemoveComment(Comment comment, Post post)
        {
            post.Comments.Remove(comment);
            BookUController.Instance.Save();
        }
    }
}
