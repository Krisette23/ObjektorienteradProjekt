using BookU_GUILayer.ViewModels.Command.HomeCommand;
using System.Windows;

namespace BookU_GUILayer.ViewModels.ForViews
{
    /// <summary>
    /// ViewModel for keeping track on which view is currently active
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        public static readonly MainViewModel Instance = new MainViewModel();
        public Home_btnCommand Home_Btn { get; } 
        public Profile_btnCommand Profile_Btn { get; }
        public MakePost_btnCommand MakePost_Btn { get; }
        public Search_btnCommand Search_Btn { get; }
        public SignOut_btnCommand SignOut_Btn { get; }
        public Notifcation_btnCommand Notifcation_Btn { get; }

        private MainViewModel() 
        {
            _selectedViewModel = LogInViewModel.Instance;
            Home_Btn = new Home_btnCommand();
            MakePost_Btn = new MakePost_btnCommand();
            Search_Btn = new Search_btnCommand();
            SignOut_Btn = new SignOut_btnCommand();
            _toolsVisibility = Visibility.Hidden;
            Profile_Btn = new Profile_btnCommand();
            Notifcation_Btn = new Notifcation_btnCommand();
            Context.GenerateData();
        }

        public void DisplayLogInView()
        {
            SelectedViewModel = LogInViewModel.Instance;
            ToolsVisibility = Visibility.Collapsed;
            UpdateBtns();
        }

        public void DisplayHomeView()
        {
            SelectedViewModel = HomePostViewModel.Instance;
            HomePostViewModel.Instance.UpdateFlow();
            UpdateBtns();
        }

        private void UpdateBtns()
        {
            Home_Btn.RaiseCanExecuteChanged();
            Profile_Btn.RaiseCanExecuteChanged();
            MakePost_Btn.RaiseCanExecuteChanged();
            Search_Btn.RaiseCanExecuteChanged();
            SignOut_Btn.RaiseCanExecuteChanged();
            Notifcation_Btn.RaiseCanExecuteChanged();
        }

        public string CurentTool { get; set; } = "";

        private ViewModelBase _tools;
        public ViewModelBase Tools
        {
            get => _tools;
            set
            {
                _tools = value;
                OnPropertyChanged("Tools");
            }
        }

        private Visibility _toolsVisibility;
        public Visibility ToolsVisibility
        {
            get => _toolsVisibility;
            set
            {
                _toolsVisibility = value;
                OnPropertyChanged("ToolsVisibility");
            }
        }

        private ViewModelBase _selectedViewModel;
        public ViewModelBase SelectedViewModel
        {
            get => _selectedViewModel;
            set
            {
                _selectedViewModel = value;
                if (_selectedViewModel != UserListViewModel.Instance)
                {
                    SearchViewModel.Instance.SearchText = "";
                    SearchViewModel.Instance.SelectedMode = SearchMode.NotSelected;
                }
                OnPropertyChanged("SelectedViewModel");
            }
        }
    }
}
