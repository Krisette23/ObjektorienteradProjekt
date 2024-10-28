using BookU_GUILayer.ViewModels.ForViews;
using System.Windows;
using System.Windows.Input;

namespace BookU_GUILayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = MainViewModel.Instance;
        }

        /// <summary>
        /// Makes it possible to move the window 
        /// </summary>
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            this.DragMove();
        }
        private void ExitProgram(object sender, RoutedEventArgs e) => Application.Current.Shutdown();
    }
}
