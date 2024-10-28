using BookU_GUILayer.ViewModels.ForViews;

namespace BookU_GUILayer.ViewModels.Command.PostCommand
{
    public class AddPicture_btnCommand: BaseCommand
    {
        private MakePostViewModel _viewModel;
        public AddPicture_btnCommand(MakePostViewModel viewModel) => _viewModel = viewModel;
        public override void Execute(object parameter) => _viewModel.LoadImage();
    }
}
