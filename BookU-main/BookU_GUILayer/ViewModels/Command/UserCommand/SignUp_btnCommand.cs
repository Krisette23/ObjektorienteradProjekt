using BookU_GUILayer.ViewModels.ForViews;

namespace BookU_GUILayer.ViewModels.Command.UserCommand
{
    public class SignUp_btnCommand : BaseCommand
    {
        public override void Execute(object parameter) => MainViewModel.Instance.SelectedViewModel = new SignUpViewModel();
    }
}
