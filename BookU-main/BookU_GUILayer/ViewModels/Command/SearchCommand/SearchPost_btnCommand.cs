using BookU_GUILayer.ViewModels.ForViews;

namespace BookU_GUILayer.ViewModels.Command.SearchCommand
{
    public class SearchPost_btnCommand : BaseCommand
    {
        public override void Execute(object parameter)
        {
            if (SearchViewModel.Instance.SelectedMode != SearchMode.Post)
            {
                MainViewModel.Instance.DisplayHomeView();
                SearchViewModel.Instance.SelectedMode = SearchMode.Post;
            }
            else
                SearchViewModel.Instance.SelectedMode = SearchMode.NotSelected;
        }
    }
}
