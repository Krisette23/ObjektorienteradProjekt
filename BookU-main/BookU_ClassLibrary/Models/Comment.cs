using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookU_ClassLibrary.Models
{
    /// <summary>
    /// Our model for all comments present in system
    /// </summary>
    [Table("Comments")]
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }
        public string Text { get; set; }
        public DateTime PublishDate { get; set; }
        public virtual User Author { get; set; }
    }
}
