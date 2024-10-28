﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BookU_GUILayer.View.UserControls
{
    /// <summary>
    /// Interaction logic for PostUserControl.xaml
    /// </summary>
    public partial class PostUserControl : UserControl
    {
        public PostUserControl() => InitializeComponent();

        /// <summary>
        /// If TextBlock is pressed when the full text is not visible, the extends the Textblock to include the full text
        /// else if textblock is already extended and is pressed then the textblock goes back to initial state
        /// </summary>
        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var height = 130;
            if (TextField.MaxHeight == height) 
                TextField.SetValue(MaxHeightProperty, DependencyProperty.UnsetValue);
            else TextField.MaxHeight = height;
        }
    }
}
