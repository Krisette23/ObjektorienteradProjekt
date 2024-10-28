using BookU_GUILayer.ViewModels.ForViews;

namespace BookU_GUILayer.ViewModels.Command.HomeCommand
{
    public class SignOut_btnCommand : BaseCommand
    {
        public override bool CanExecute(object parameter) => MainViewModel.Instance.Context.CurrentUser != null;
        public override void Execute(object parameter)
        {
            MainViewModel.Instance.Context.CurrentUser = null;
            MainViewModel.Instance.DisplayLogInView();
        }
    }
}
