using BookU_ClassLibrary.Models;
using BookU_GUILayer.ViewModels.ForUserControls;
using System.Collections.Generic;
using System.Linq;

namespace BookU_GUILayer.ViewModels.Command.PostCommand
{
    public class Like_btnCommand : BaseCommand
    {
        private PostViewModel _viewModel;
        public Like_btnCommand(PostViewModel postViewModel) => _viewModel = postViewModel;
        public override void Execute(object parameter)
        {
            List<Like> likeList = _viewModel.Likes;
            if (_viewModel.GetLikeStatus() == _viewModel._likeBtn)
            {
                _viewModel.LikeColor = _viewModel._likeClickedBtn;
                likeList.Add(new Like() { UserID = _viewModel.Context.CurrentUser.SNumber });
            }
            else { 
                _viewModel.LikeColor = _viewModel._likeBtn;
                likeList.Remove(likeList.Where(l => l.UserID == _viewModel.Context.CurrentUser.SNumber).FirstOrDefault());
            } 
            _viewModel.Likes = likeList;
        }
    }
}
