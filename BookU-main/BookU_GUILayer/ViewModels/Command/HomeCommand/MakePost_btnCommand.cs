using BookU_GUILayer.ViewModels.ForViews;
using System.Windows;

namespace BookU_GUILayer.ViewModels.Command.HomeCommand
{
    public class MakePost_btnCommand : BaseCommand
    {
        public override bool CanExecute(object parameter) => MainViewModel.Instance.Context.CurrentUser != null;
        public override void Execute(object parameter)
        {
            if (MainViewModel.Instance.CurentTool != "MakePost")
            {
                MainViewModel.Instance.ToolsVisibility = Visibility.Visible;
                MainViewModel.Instance.Tools = new MakePostViewModel();
                MainViewModel.Instance.CurentTool = "MakePost";
            }
            else
            {
                MainViewModel.Instance.ToolsVisibility = Visibility.Collapsed;
                MainViewModel.Instance.CurentTool = "";
            }
        }
    }
}
