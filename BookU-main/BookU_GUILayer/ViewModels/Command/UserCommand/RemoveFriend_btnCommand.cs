using BookU_ClassLibrary.Models;
using BookU_GUILayer.ViewModels.ForUserControls;
using BookU_GUILayer.ViewModels.ForViews;
using System.Collections.Generic;
using System.Linq;

namespace BookU_GUILayer.ViewModels.Command.UserCommand
{
    public class RemoveFriend_btnCommand : BaseCommand
    {
        private UserViewModel _viewModel;
        public RemoveFriend_btnCommand(UserViewModel viewModel) => _viewModel = viewModel;
        public override bool CanExecute(object parameter)
        {
            List<User> users = new List<User>();
            MainViewModel.Instance.Context.CurrentUser.Friends.ToList().ForEach(f => users.Add(f.GetFriend(MainViewModel.Instance.Context.CurrentUser)));
            foreach (User user in users)
                if (user.SNumber == _viewModel.SNum) return true;
            return false;
        }

        public override void Execute(object parameter)
        {
            MainViewModel.Instance.Context.UController.RemoveFriend(MainViewModel.Instance.Context.CurrentUser, _viewModel.ThisUser);
            UserListViewModel.Instance.UpdateList();
            _viewModel.AddFriend_Btn.RaiseCanExecuteChanged();
        }
    }
}
