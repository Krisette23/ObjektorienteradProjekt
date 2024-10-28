using BookU_GUILayer.ViewModels.ForViews;
using System.Windows;

namespace BookU_GUILayer.ViewModels.Command.HomeCommand
{
    public class Search_btnCommand : BaseCommand
    {
        public override bool CanExecute(object parameter) => MainViewModel.Instance.Context.CurrentUser != null;
        public override void Execute(object parameter)
        {
            if (MainViewModel.Instance.CurentTool != "Search")
            {
                MainViewModel.Instance.ToolsVisibility = Visibility.Visible;
                MainViewModel.Instance.Tools = SearchViewModel.Instance;
                MainViewModel.Instance.CurentTool = "Search";
            }
            else
            {
                MainViewModel.Instance.ToolsVisibility = Visibility.Collapsed;
                MainViewModel.Instance.CurentTool = "";
            }
        }
    }
}
