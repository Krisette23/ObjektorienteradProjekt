using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Windows.Media;

namespace BookU_ClassLibrary.Models
{
    /// <summary>
    /// Our model for all post present in system
    /// </summary>
    [Table ("Posts")]
    public class Post
    {
        public Post()
        {
            Comments = new List<Comment>();
            Likes = new List<Like>();
            PublishDate = DateTime.Today;
        }

        [Key]
        public int PostID { get; set; }
        public string Text { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
        public DateTime PublishDate { get; set; }
        public virtual User Author { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public byte[] Picture{ get; set; }
    }
}
