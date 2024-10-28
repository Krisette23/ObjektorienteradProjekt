using BookU_GUILayer.ViewModels.ForUserControls;
using System.Collections.ObjectModel;
using System.Linq;

namespace BookU_GUILayer.ViewModels.ForViews
{
    class NotificationListViewModel : ViewModelBase
    {
        public static readonly NotificationListViewModel Instance = new NotificationListViewModel();
        public NotificationListViewModel() => UpdateList();
        public void UpdateList()
        {
            Notifications.Clear();
            MainViewModel.Instance.Context.CurrentUser.PendingFriendRequests.ToList().ForEach(p => Notifications.Add(new NotificationViewModel(p)));
        }
        public ObservableCollection<NotificationViewModel> Notifications { get; } 
            = new ObservableCollection<NotificationViewModel>();
    }
}
