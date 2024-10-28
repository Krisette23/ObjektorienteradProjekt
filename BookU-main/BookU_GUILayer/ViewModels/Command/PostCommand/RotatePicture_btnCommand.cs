using BookU_GUILayer.ViewModels.ForUserControls;

namespace BookU_GUILayer.ViewModels.Command.PostCommand
{
    public class RotatePicture_btnCommand : BaseCommand
    {
        private PostViewModel _viewModel;
        public RotatePicture_btnCommand(PostViewModel viewModel) => _viewModel = viewModel;
        public override bool CanExecute(object parameter) => _viewModel.Image != "";
        public override void Execute(object parameter) => _viewModel.RotateImage();
    }
}
