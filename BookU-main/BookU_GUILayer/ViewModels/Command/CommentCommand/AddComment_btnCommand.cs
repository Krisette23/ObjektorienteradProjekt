using BookU_ClassLibrary.Models;
using BookU_GUILayer.ViewModels.ForUserControls;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace BookU_GUILayer.ViewModels.Command.CommentCommand
{
    public class AddComment_btnCommand : BaseCommand
    {
        public override event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
        private PostViewModel _viewModel;
        public AddComment_btnCommand(PostViewModel viewModel) => _viewModel = viewModel;

        public override bool CanExecute(object parameter) => !string.IsNullOrWhiteSpace(_viewModel.CommentText) && !string.Equals(_viewModel.CommentText, " Write a comment here...");
        public override void Execute(object parameter)
        {
            List<Comment> tempList = _viewModel.Comments;
            tempList.Add(new Comment()
            {
                Author = _viewModel.Context.CurrentUser,
                PublishDate = DateTime.Now,
                Text = _viewModel.CommentText
            });
            _viewModel.Comments = tempList;
            _viewModel.CommentText = default;
            if (tempList.Count == 2)
                _viewModel.HandleShownComments();
        }
    }
}
