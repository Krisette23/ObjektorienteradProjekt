using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookU_ClassLibrary.Models
{
    public class Like
    {
        [Key]
        public int LikeID { get; set; }
        public string UserID { get; set; }
    }
}
