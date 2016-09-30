using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MahappsDragAndDrop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        // From:
        // https://social.msdn.microsoft.com/Forums/vstudio/en-US/942d19a8-b862-48aa-883a-d59ad6acaa2a/dragdrop-image-to-canvas?forum=wpf

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            SettingsFlyout.IsOpen = true;
        }

        private void SettingsList_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Image image = e.Source as Image;
            DataObject data = new DataObject(typeof(ImageSource), image.Source);
            DragDrop.DoDragDrop(image, data, DragDropEffects.Copy);
        }

        private void DesignSurface_Drop(object sender, DragEventArgs e)
        {
            ImageSource image = e.Data.GetData(typeof(ImageSource)) as ImageSource;
            Image imageControl = new Image() { Width = image.Width, Height = image.Height, Source = image };
            Canvas.SetLeft(imageControl, e.GetPosition(DesignSurface).X);
            Canvas.SetTop(imageControl, e.GetPosition(DesignSurface).Y);
            DesignSurface.Children.Add(imageControl);
        }
    }
}
