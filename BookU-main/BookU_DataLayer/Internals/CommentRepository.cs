using BookU_ClassLibrary.Context;
using BookU_ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookU_ClassLibrary.Internals
{
    public class CommentRepository: Repository<Comment>, ICommentRepository
    {
        public CommentRepository(BookUDBContext context) : base(context){}
        public BookUDBContext BookUDBContext
        {
            get { return _context; }
        }
    }
}
