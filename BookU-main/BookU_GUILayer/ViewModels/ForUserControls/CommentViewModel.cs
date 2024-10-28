using BookU_ClassLibrary.Models;
using BookU_GUILayer.ViewModels.Command.CommentCommand;
using System;

namespace BookU_GUILayer.ViewModels.ForUserControls
{
    /// <summary>
    /// ViewModel for all comments in system
    /// </summary>
    public class CommentViewModel : ViewModelBase
    {
        public CommentViewModel(Comment comment, Post post)
        {
            _post = post;
            _text = comment.Text;
            _publishDate = comment.PublishDate;
            _author = comment.Author;
            DeleteComment_Btn = new DeleteComment_btnCommand(post, comment);
        }

        public DeleteComment_btnCommand DeleteComment_Btn { get; }

        private Post _post;

        private string _text;
        public string Text
        {
            get { return _text; }
            set {
                _text = value;
                OnPropertyChanged("Text");
            }
        }

        private DateTime _publishDate;
        public DateTime PublishDate
        {
            get { return _publishDate; }
            set {
                _publishDate = value;
                OnPropertyChanged("PublishDate");
            }
        }
        private User _author;
        public User Author
        {
            get { return _author; }
            set {
                _author = value;
                OnPropertyChanged("Author");
            }
        }
    }
}
