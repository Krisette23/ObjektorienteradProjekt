using BookU_ClassLibrary.Models;
using BookU_GUILayer.ViewModels.ForViews;

namespace BookU_GUILayer.ViewModels.Command.CommentCommand
{
    public class DeleteComment_btnCommand : BaseCommand
    {
        private Post _thisPost;
        private Comment _thisComment;
        public DeleteComment_btnCommand(Post post, Comment comment)
        {
            _thisPost = post;
            _thisComment = comment;
        }
        public override bool CanExecute(object parameter) => _thisComment.Author == MainViewModel.Instance.Context.CurrentUser;
        public override void Execute(object parameter)
        {
            MainViewModel.Instance.Context.CController.RemoveComment(_thisComment, _thisPost);
            HomePostViewModel.Instance.UpdateFlow();
        }
    }
}
