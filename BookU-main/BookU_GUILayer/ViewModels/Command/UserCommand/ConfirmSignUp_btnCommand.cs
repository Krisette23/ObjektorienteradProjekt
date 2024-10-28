using BookU_ClassLibrary.Models;
using BookU_GUILayer.ViewModels.ForViews;
using System;

namespace BookU_GUILayer.ViewModels.Command.UserCommand
{
    class ConfirmSignUp_btnCommand : BaseCommand
    {
        private SignUpViewModel _viewModel;
        public ConfirmSignUp_btnCommand(SignUpViewModel viewModel) => _viewModel = viewModel;

        public override bool CanExecute(object parameter) => !string.IsNullOrWhiteSpace(_viewModel.Email) && _viewModel.Password != null
                && !string.IsNullOrWhiteSpace(_viewModel.Name) && !string.IsNullOrWhiteSpace(_viewModel.SNumber)
                && !string.IsNullOrWhiteSpace(_viewModel.AttendingProgram) && _viewModel.BirthDay != DateTime.Today;

        public override void Execute(object parameter)
        {
            User newUser = new User()
            {
                SEmail = _viewModel.Email,
                Password = _viewModel.Password,
                Name = _viewModel.Name,
                SNumber = _viewModel.SNumber,
                AttendingProgram = _viewModel.AttendingProgram,
                BirthDate = _viewModel.BirthDay,
            };

            _viewModel.Context.UController.AddUser(newUser);
            _viewModel.Context.UController.ValidateUser(newUser.SEmail, newUser.Password);
            _viewModel.MainView.DisplayHomeView();
        }
    }
}
