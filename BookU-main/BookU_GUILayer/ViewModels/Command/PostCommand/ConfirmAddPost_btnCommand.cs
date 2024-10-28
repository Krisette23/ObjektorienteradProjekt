using BookU_ClassLibrary.Models;
using BookU_GUILayer.ViewModels.ForViews;
using System;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace BookU_GUILayer.ViewModels.Command.PostCommand
{
    public class ConfirmAddPost_btnCommand : BaseCommand
    {
        public override event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        private MakePostViewModel _viewModel;
        public ConfirmAddPost_btnCommand(MakePostViewModel viewModel) => _viewModel = viewModel;

        public override bool CanExecute(object parameter) =>
            !string.IsNullOrWhiteSpace(_viewModel.Text) || 
            !string.IsNullOrWhiteSpace(_viewModel.ImagePath);
        
        public override void Execute(object parameter)
        {
            Post newPost = new Post()
            {
                Author = _viewModel.Context.CurrentUser,
                PublishDate = DateTime.Now,
                Text = _viewModel.Text
            };

            if (_viewModel.ImagePath != "")
                newPost.Picture = Encoding.ASCII.GetBytes(_viewModel.ImagePath); 

            MainViewModel.Instance.Context.PController.AddPost(newPost); 
            MainViewModel.Instance.ToolsVisibility = Visibility.Collapsed;
            HomePostViewModel.Instance.UpdateFlow();
            _viewModel.Text = default;
        }
    }
}
