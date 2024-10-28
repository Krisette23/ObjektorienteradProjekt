using BookU_ClassLibrary.Models;
using BookU_GUILayer.ViewModels.ForViews;

namespace BookU_GUILayer.ViewModels.Command.PostCommand
{
    public class DeletePost_btnCommand : BaseCommand
    {
        private Post _thisPost;
        public DeletePost_btnCommand(Post post) => _thisPost = post;
        public override bool CanExecute(object parameter) => _thisPost.Author == MainViewModel.Instance.Context.CurrentUser;
        public override void Execute(object parameter)
        {
            MainViewModel.Instance.Context.PController.RemovePost(_thisPost);
            HomePostViewModel.Instance.UpdateFlow();
        }
    }
}
