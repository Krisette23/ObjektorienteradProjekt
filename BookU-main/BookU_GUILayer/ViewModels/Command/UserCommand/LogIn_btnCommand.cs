using BookU_GUILayer.ViewModels.ForViews;

namespace BookU_GUILayer.ViewModels.Command.UserCommand
{
    public class LogIn_btnCommand : BaseCommand
    {
        public override bool CanExecute(object parameter = null) => 
            !string.IsNullOrWhiteSpace(LogInViewModel.Instance.Email) && !string.IsNullOrWhiteSpace(LogInViewModel.Instance.Password);

        public override void Execute(object parameter)
        {
            if (!string.IsNullOrWhiteSpace(LogInViewModel.Instance.Email) && !string.IsNullOrWhiteSpace(LogInViewModel.Instance.Password) &&
                LogInViewModel.Instance.Context.UController.ValidateUser(LogInViewModel.Instance.Email, LogInViewModel.Instance.Password))
                MainViewModel.Instance.DisplayHomeView();
        }
    }
}
