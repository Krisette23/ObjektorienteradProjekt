using BookU_ClassLibrary.Context;
using BookU_ClassLibrary.Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace BookU_ClassLibrary.Internals
{
    /// <summary>
    /// This is the main Data controller that receives saved data, distributes the data and saves new data
    /// </summary>
    public class DataController : IDataController
    {
        public IUserRepository Users { get; }
        public IPostRepository Posts { get; }
        public ICommentRepository Comments { get; }
        private BookUDBContext _context;
        public DataController()
        {
            _context = new BookUDBContext();
            Users = new UserRepository(_context);
            Posts = new PostRepository(_context);
            Comments = new CommentRepository(_context);
            Init();
        }
        public void Init() => _context.Reset();
        public int Complete() => _context.SaveChanges();
        public void Dispose() => _context.Dispose();
    }
}