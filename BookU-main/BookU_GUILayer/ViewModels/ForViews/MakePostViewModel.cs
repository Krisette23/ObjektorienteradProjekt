using BookU_GUILayer.ViewModels.Command.PostCommand;
using Microsoft.Win32;

namespace BookU_GUILayer.ViewModels.ForViews
{
    public class MakePostViewModel : ViewModelBase
    {
        public ConfirmAddPost_btnCommand ConfirmAddPost_Btn { get; }
        public AddPicture_btnCommand AddPicture_Btn { get; }
        public MakePostViewModel()
        {
            AddPicture_Btn = new AddPicture_btnCommand(this);
            ConfirmAddPost_Btn = new ConfirmAddPost_btnCommand(this);
        }
        private string _text;
        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                OnPropertyChanged("Text");
            }
        }
        private string _imagePath;
        public string ImagePath
        {
            get { return _imagePath; }
            set
            {
                if(value!= _imagePath)
                {
                    _imagePath = value;
                    OnPropertyChanged("ImagePath");
                }
            }
        }
      
        
        public void LoadImage()
        {
            OpenFileDialog open = new OpenFileDialog
            {
                Title = "Select A Picture",
                DefaultExt = (".png"),
                Filter = "(Pictures (*.jpg;*.gif;*.png)|*.jpg;*.gif;*.png)"
            };
            if (open.ShowDialog() == true)
                ImagePath =(open.FileName);
        }
        
    }
}
