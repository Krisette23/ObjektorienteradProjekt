using BookU_ClassLibrary.Models;
using BookU_GUILayer.ViewModels.Command.NotificationCommand;
using BookU_GUILayer.ViewModels.ForViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookU_GUILayer.ViewModels.ForUserControls
{
    class NotificationViewModel : ViewModelBase
    {
        public NotificationViewModel(Friend request)
        {
            Friend = request.GetFriend(MainViewModel.Instance.Context.CurrentUser);
            AcceptFriend_Btn = new AcceptFriend_btnCommand(this);
            DeclineFriend_Btn = new DeclineFriend_btnCommand(this);
        }
        public AcceptFriend_btnCommand AcceptFriend_Btn { get; }
        public DeclineFriend_btnCommand DeclineFriend_Btn { get; } 
        public User Friend { get; }
        public string Message => Friend.Name + " wants to be your friend. Do you accept?";
    }
}
