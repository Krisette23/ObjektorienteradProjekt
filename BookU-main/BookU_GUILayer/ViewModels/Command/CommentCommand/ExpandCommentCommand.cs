using BookU_GUILayer.ViewModels.ForUserControls;

namespace BookU_GUILayer.ViewModels.Command.CommentCommand
{
    public class ExpandCommentCommand : BaseCommand
    {
        private PostViewModel _postViewModel;
        public ExpandCommentCommand(PostViewModel postViewModel) => _postViewModel = postViewModel;
        public override bool CanExecute(object parameter) => _postViewModel.Comments.Count > 1;
        public override void Execute(object parameter) => _postViewModel.HandleShownComments();
    }
}