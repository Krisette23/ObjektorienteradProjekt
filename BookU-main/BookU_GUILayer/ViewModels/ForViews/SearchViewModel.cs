using BookU_GUILayer.ViewModels.Command.SearchCommand;
using System.Windows;

namespace BookU_GUILayer.ViewModels.ForViews
{
    class SearchViewModel : ViewModelBase
    {
        public static readonly SearchViewModel Instance = new SearchViewModel();
        private SearchViewModel()
        {
            _searchInput = Visibility.Collapsed;
            _selectedMode = SearchMode.NotSelected;
            SearchPost_Btn = new SearchPost_btnCommand();
            SearchUser_Btn = new SearchUser_btnCommand();
        }

        public SearchPost_btnCommand SearchPost_Btn { get; }
        public SearchUser_btnCommand SearchUser_Btn { get; }
        internal SearchMode _selectedMode;
        public SearchMode SelectedMode
        {
            get => _selectedMode;
            set
            {
                _selectedMode = value;
                if (_selectedMode == SearchMode.NotSelected)
                    SearchInput = Visibility.Collapsed;
                else
                    SearchInput = Visibility.Visible;
            }
        }

        private Visibility _searchInput;
        public Visibility SearchInput
        {
            get => _searchInput;
            set
            {
                _searchInput = value;
                OnPropertyChanged("SearchInput");
            }
        }
        private string _searchText;
        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                if (SelectedMode == SearchMode.Post)
                    HomePostViewModel.Instance.UpdateFlow(_searchText);
                else if (SelectedMode == SearchMode.User)
                    UserListViewModel.Instance.UpdateList(_searchText);
                OnPropertyChanged("SearchText");
            }
        }
    }

    internal enum SearchMode
    {
        User,
        Post,
        NotSelected,
    }
}
