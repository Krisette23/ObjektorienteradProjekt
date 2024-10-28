﻿using BookU_ClassLibrary.Models;
using BookU_GUILayer.ViewModels.ForUserControls;
using BookU_GUILayer.ViewModels.ForViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookU_GUILayer.ViewModels.Command.NotificationCommand
{
    class AcceptFriend_btnCommand : BaseCommand
    {
        private NotificationViewModel _viewModel;
        public AcceptFriend_btnCommand(NotificationViewModel viewModel) => _viewModel = viewModel; 
        public override void Execute(object parameter)
        {
            MainViewModel.Instance.Context.UController.HandleFriendRequest(MainViewModel.Instance.Context.CurrentUser, _viewModel.Friend, FriendRequestFlag.Approved);
            MainViewModel.Instance.Context.UController.RemovePendingRequest(_viewModel.Friend, MainViewModel.Instance.Context.CurrentUser);
            NotificationListViewModel.Instance.UpdateList();
            MainViewModel.Instance.Notifcation_Btn.RaiseCanExecuteChanged();
        }
    }
}
