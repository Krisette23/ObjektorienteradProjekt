using BookU_ClassLibrary.Models;
using BookU_GUILayer.ViewModels.ForUserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookU_GUILayer.ViewModels.ForViews
{
    class UserListViewModel : ViewModelBase
    {
        public static readonly UserListViewModel Instance = new UserListViewModel();
        private UserListViewModel() => UpdateList();
        public void UpdateList(string filter = "")
        {
            Users = new ObservableCollection<UserViewModel>();
            List<User> allUsers = Context.UController.GetAllUsers()?.ToList();

            if (filter != "")
            {
                List<User> tempList = allUsers;
                allUsers = new List<User>();
                foreach(User user in tempList)
                    if (user.Name.Contains(filter))
                        allUsers.Add(user);
            }

            if (allUsers.Count > 0)
                foreach (User user in allUsers)
                    if (user != MainViewModel.Instance.Context.CurrentUser)
                        Users.Add(new UserViewModel(user));
        }

        private ObservableCollection<UserViewModel> _users;
        public ObservableCollection<UserViewModel> Users
        {
            get => _users;
            set
            {
                _users = value;
                OnPropertyChanged("Users");
            }
        }
    }
}
