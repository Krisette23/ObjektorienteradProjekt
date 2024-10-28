using BookU_ClassLibrary.Models;
using System;

namespace BookU_ClassLibrary.Internals
{
    /// <summary>
    /// A Interface for DataController class
    /// </summary>
    public interface IDataController: IDisposable
    {
        IUserRepository Users { get; }
        IPostRepository Posts { get; }
        ICommentRepository Comments { get; }
        /// <summary>
        /// Commits all changes
        /// </summary>
        int Complete();
    }
} 
