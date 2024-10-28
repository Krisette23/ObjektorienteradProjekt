using BookU_GUILayer.ViewModels.ForViews;

namespace BookU_GUILayer.ViewModels.Command.SearchCommand
{
    class SearchUser_btnCommand : BaseCommand
    {
        public override void Execute(object parameter)
        {
            if (SearchViewModel.Instance.SelectedMode != SearchMode.User)
            {
                SearchViewModel.Instance.SelectedMode = SearchMode.User;
                MainViewModel.Instance.SelectedViewModel = UserListViewModel.Instance;
            }
            else
            {
                SearchViewModel.Instance.SelectedMode = SearchMode.NotSelected;
                MainViewModel.Instance.SelectedViewModel = HomePostViewModel.Instance;
            }
        }
    }
}
