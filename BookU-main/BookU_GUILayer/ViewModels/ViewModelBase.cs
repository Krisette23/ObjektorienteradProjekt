using BookU_BusinessLayer;
using GalaSoft.MvvmLight;
using System.ComponentModel;


namespace BookU_GUILayer.ViewModels
{
    /// <summary>
    /// Main ViewModel that Creates the fundation for all viewModels
    /// </summary>
    public class ViewModelBase : INotifyPropertyChanged
    {
        public BookUController Context { get;}
        public event PropertyChangedEventHandler PropertyChanged;
        public ViewModelBase() => Context = BookUController.Instance;

        /// <summary>
        /// Informs everyone that is subscribed to a property that the property has uppdated its value
        /// </summary>
        protected void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
