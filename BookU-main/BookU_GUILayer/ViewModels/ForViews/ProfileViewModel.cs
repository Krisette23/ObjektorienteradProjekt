using BookU_ClassLibrary.Models;
using BookU_GUILayer.ViewModels.ForUserControls;
using System.Collections.ObjectModel;
using System.Linq;

namespace BookU_GUILayer.ViewModels.ForViews
{
    /// <summary>
    /// Is used for all binding on profile view
    /// </summary>
    class ProfileViewModel : ViewModelBase
    {
        private User _user;
        public ProfileViewModel(User user)
        {
            _user = user;
            Context.PController.GetUserPost(user)?.ForEach(p => Posts.Add(new PostViewModel(p)));
            Context.CurrentUser.Friends?.ToList().ForEach(f => Friends.Add(new FriendViewModel(f.GetFriend(user))));
        }

        public ObservableCollection<PostViewModel> Posts { get; set; }
            = new ObservableCollection<PostViewModel>();

        public ObservableCollection<FriendViewModel> Friends { get; set; }
            = new ObservableCollection<FriendViewModel>();

        //public BitmapImage ProfilePic => ConvertImage.ToImage(_user.ProfilePicture);
        public string Name => _user.Name;
        public string YearOfBirth => _user.BirthDate.ToShortDateString();
        public string AttendingProgram => _user.AttendingProgram;
        public string SNumber => _user.SNumber;
    }
}
