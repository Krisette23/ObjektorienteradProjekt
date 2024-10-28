using BookU_GUILayer.ViewModels.Command.UserCommand;
using System;

namespace BookU_GUILayer.ViewModels.ForViews
{
    class SignUpViewModel : ViewModelBase
    {
        public ConfirmSignUp_btnCommand Confirm_Btn { get; }
        public MainViewModel MainView { get; }
        public SignUpViewModel()
        {
            MainView = MainViewModel.Instance;
            Confirm_Btn = new ConfirmSignUp_btnCommand(this);
            _birthDay = DateTime.Today;
        }

        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                
                _email = value;
                Confirm_Btn.RaiseCanExecuteChanged();
            }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                Confirm_Btn.RaiseCanExecuteChanged();
            }
        }

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                Confirm_Btn.RaiseCanExecuteChanged();
            }
        }

        private string _sNumber;
        public string SNumber
        {
            get => _sNumber;
            set
            {
                _sNumber = value;
                Confirm_Btn.RaiseCanExecuteChanged();
            }
        }

        private string _attendingProgram;
        public string AttendingProgram
        {
            get => _attendingProgram;
            set
            {
                _attendingProgram = value;
                Confirm_Btn.RaiseCanExecuteChanged();
            }
        }

        private DateTime _birthDay;
        public DateTime BirthDay
        {
            get
            {
                if (_birthDay != null)
                    return _birthDay;
                else return DateTime.Now;
            }

            set
            {
                _birthDay = value;
                Confirm_Btn.RaiseCanExecuteChanged();
            }
        }
        public DateTime Today
        {
            get => DateTime.Today;
        }
    }
}
