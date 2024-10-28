using BookU_ClassLibrary.Context;
using BookU_ClassLibrary.Internals;
using BookU_ClassLibrary.Models;
using System.Linq;

namespace BookU_BusinessLayer
{
    public class BookUController
    {
        public static readonly BookUController Instance = new BookUController();
        internal IDataController Context { get; }
        public User CurrentUser { get; set; } = null;
        public UserController UController { get; }
        public PostController PController { get; }
        public CommentController CController { get; }
        private BookUController()
        {
            Context = new DataController();
            UController = new UserController();
            PController = new PostController();
            CController = new CommentController();
        }

        public void Save() => Context.Complete();
        public void GenerateData() => new TESTDATA();
    }
}
