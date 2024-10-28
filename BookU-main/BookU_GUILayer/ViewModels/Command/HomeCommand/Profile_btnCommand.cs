using BookU_ClassLibrary.Models;
using BookU_GUILayer.ViewModels.ForViews;

namespace BookU_GUILayer.ViewModels.Command.HomeCommand
{
    public class Profile_btnCommand : BaseCommand
    {
        private User _user;
        public Profile_btnCommand(User user) => _user = user;
        public Profile_btnCommand() => _user = null;
        public override bool CanExecute(object parameter) => MainViewModel.Instance.Context.CurrentUser != null;
        public override void Execute(object parameter)
        {
            if(_user == null)
                _user = MainViewModel.Instance.Context.CurrentUser;
            MainViewModel.Instance.SelectedViewModel = new ProfileViewModel(_user);
        }
    }
}
