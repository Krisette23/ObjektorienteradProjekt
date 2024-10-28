using BookU_GUILayer.ViewModels.ForViews;
using System.Linq;

namespace BookU_GUILayer.ViewModels.Command.HomeCommand
{
    public class Notifcation_btnCommand : BaseCommand
    {
        public override bool CanExecute(object parameter) => 
            MainViewModel.Instance.Context.CurrentUser?.PendingFriendRequests.Count() > 0;
        public override void Execute(object parameter) => MainViewModel.Instance.SelectedViewModel = NotificationListViewModel.Instance;
    }
}
