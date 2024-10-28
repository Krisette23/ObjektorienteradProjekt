using BookU_ClassLibrary.Models;
using BookU_GUILayer.ViewModels.ForUserControls;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BookU_GUILayer.ViewModels.ForViews
{
    /// <summary>
    /// ViewModel for all Post in the Home screen
    /// </summary>
    public class HomePostViewModel : ViewModelBase
    {
        public static readonly HomePostViewModel Instance = new HomePostViewModel();
        public void UpdateFlow(string filter = "")
        {
            Posts = new ObservableCollection<PostViewModel>();
            List<Post> AllPost = Context.PController.GetUserFlow(Context.CurrentUser);

            if (filter != "")
            {
                List<Post> TempPosts = AllPost;
                AllPost = new List<Post>();
                
                foreach (Post post in TempPosts)
                    if (post.Text.Contains(filter) || post.Author.Name.Contains(filter))
                        AllPost.Add(post);
            }
            AllPost?.ForEach(p => Posts.Add(new PostViewModel(p))); 
        }

        /// <summary>
        /// Home view is bound to this list of Post UIs
        /// </summary>
        private ObservableCollection<PostViewModel> _posts;
        public ObservableCollection<PostViewModel> Posts
        {
            get => _posts;
            set
            {
                _posts = value;
                OnPropertyChanged("Posts");
            }
        }
    }
}
