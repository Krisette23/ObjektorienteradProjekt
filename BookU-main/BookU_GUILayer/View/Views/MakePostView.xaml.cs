using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;


namespace BookU_GUILayer.View.Views
{
    /// <summary>
    /// Interaction logic for MakePostView.xaml
    /// </summary>
    public partial class MakePostView : UserControl
    {
        public MakePostView()
        {
            InitializeComponent();
        }
        private void Thumb_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var thumb = e.Source as UIElement;
            var transform = thumb.RenderTransform as RotateTransform;
            transform.Angle += 90;
        }
        
    }
}
