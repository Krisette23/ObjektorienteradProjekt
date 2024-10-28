using BookU_ClassLibrary.Models;
using BookU_GUILayer.ViewModels.Command.CommentCommand;
using BookU_GUILayer.ViewModels.Command.HomeCommand;
using BookU_GUILayer.ViewModels.Command.PostCommand;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace BookU_GUILayer.ViewModels.ForUserControls
{
    /// <summary>
    /// ViewModel for each individual post 
    /// </summary>
    public class PostViewModel : ViewModelBase
    {
        internal readonly SolidColorBrush _likeBtn = new SolidColorBrush(Color.FromRgb(228, 230, 235));
        internal readonly SolidColorBrush _likeClickedBtn = new SolidColorBrush(Color.FromRgb(19, 160, 249));
        public PostViewModel(Post post)
        {
            CurrentPost = post;
            _text = post.Text;
            if (post.Picture != null) _image = Encoding.UTF8.GetString(post.Picture);
            Comments = post.Comments.ToList();
            _likeColor = GetLikeStatus();
            Like_Btn = new Like_btnCommand(this);
            AddComment_Btn = new AddComment_btnCommand(this);
            ExpandComment = new ExpandCommentCommand(this);
            Profile_Btn = new Profile_btnCommand(post.Author);
            DeletePost_Btn = new DeletePost_btnCommand(post);
            RotatePictureCommand_Btn = new RotatePicture_btnCommand(this);
        }

        /// <summary>
        /// Each Post is bound to this list of Comment UIs
        /// </summary>
        public ObservableCollection<CommentViewModel> CommentsUC { get; set; } =
                new ObservableCollection<CommentViewModel>();

        #region Properties
        public Like_btnCommand Like_Btn { get; }
        public Profile_btnCommand Profile_Btn { get; set; }
        public AddComment_btnCommand AddComment_Btn { get; }
        public ExpandCommentCommand ExpandComment { get; set; }
        public DeletePost_btnCommand DeletePost_Btn { get; set; }
        public RotatePicture_btnCommand RotatePictureCommand_Btn { get; }
        public Post CurrentPost { get; }

        private Visibility _commmentVisibility;
        public Visibility CommentVisibility
        {
            get => _commmentVisibility;
            set
            {
                _commmentVisibility = value;
                OnPropertyChanged("CommentVisibility");
            }
        }

        private string _text;
        public string Text {
            get => _text;
            set {
                _text = value;
                OnPropertyChanged("Text");
            }
        }

        public List<Like> Likes {
            get => CurrentPost.Likes.ToList();
            set {
                CurrentPost.Likes = value;
                OnPropertyChanged("Likes");
            }
        }

        public DateTime DateTime => CurrentPost.PublishDate;
        public User User => CurrentPost.Author;

        
        private string _image;
        public string Image
        {
            get => _image;
            set
            {
                _image = value;
                OnPropertyChanged("Image");
            }
        }

        private bool _expanded;
        public bool Expanded
        {
            get => _expanded;
            set
            {
                _expanded = value;
                OnPropertyChanged("Expanded");
            }
        }

        private SolidColorBrush _likeColor;
        public SolidColorBrush LikeColor
        {
            get => _likeColor;
            set
            {
                _likeColor = value;
                OnPropertyChanged("LikeColor");
            }
        }

        public List<Comment> Comments
        {
            get => CurrentPost.Comments.ToList();
            set
            {
                CurrentPost.Comments = value;
                FillCommentList();
                OnPropertyChanged("Comments");
            }
        }
        private string _commentText;
        public string CommentText
        {
            get => _commentText;
            set
            {
                _commentText = value;
                OnPropertyChanged("CommentText");
            }
        }
        private double _rotateAngle;
        public double RotateAngle
        {
            get => _rotateAngle;

            set
            {
                if (value != _rotateAngle)
                {
                    _rotateAngle = value;
                    OnPropertyChanged("RotateAngle");
                }
            }
        }
        #endregion

        #region Functions
        public SolidColorBrush GetLikeStatus()
        {
            if (CurrentPost.Likes.Where(l => l.UserID == Context.CurrentUser.SNumber)?.FirstOrDefault() == null)
                return _likeBtn;
            else return _likeClickedBtn;
        }
        
        public void FillCommentList()
        {
            CommentsUC.Clear();
            if (CurrentPost.Comments.Count > 0)
            {
                if (Expanded) CurrentPost.Comments.ToList().ForEach(c => CommentsUC.Add(new CommentViewModel(c, CurrentPost)));
                else CommentsUC.Add(new CommentViewModel(CurrentPost.Comments.Where(c => !string.IsNullOrWhiteSpace(c.Text)).FirstOrDefault(), CurrentPost));
                CommentVisibility = Visibility.Visible;
            }
            else CommentVisibility = Visibility.Collapsed;
        }

        public void HandleShownComments()
        {
            if(_expanded) _expanded = false;
            else _expanded = true;
            FillCommentList();
        }
        public double RotateImage()
        {
            return RotateAngle += 90;
        }

        #endregion
    }
}
