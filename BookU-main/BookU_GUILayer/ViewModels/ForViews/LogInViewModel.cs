using BookU_GUILayer.ViewModels.Command.UserCommand;

namespace BookU_GUILayer.ViewModels.ForViews
{
    public class LogInViewModel : ViewModelBase
    {
        public static readonly LogInViewModel Instance = new LogInViewModel();
        public LogIn_btnCommand LogIn_Btn { get; } 
        public SignUp_btnCommand SignUp_Btn { get; } 
        private LogInViewModel()
        {
            LogIn_Btn = new LogIn_btnCommand();
            SignUp_Btn = new SignUp_btnCommand();
        }

        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                LogIn_Btn.RaiseCanExecuteChanged();
                OnPropertyChanged("Email");
            }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                LogIn_Btn.RaiseCanExecuteChanged();
                OnPropertyChanged("Password");
            }
        }
    }
}
