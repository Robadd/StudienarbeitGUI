using Microsoft.Win32;
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
using System.Windows.Shapes;

namespace Studienarbeit
{
    /// <summary>
    /// Interaktionslogik für ImageEigWindow.xaml
    /// </summary>
    public partial class ImageEigWindow : Window
    {
        public ImageEigWindow()
        {
            InitializeComponent();
        }
        bool imageIsLoaded = false;

        Image Img
        {
            get { return Image; }
            set { Image = value; }
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            if (imageIsLoaded)
                DialogResult = true;
            else
                DialogResult = false;

            this.Close();
        }

        private void Abbruch_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }

        private void BildLaden_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Bitmap (*.bmp)|*.bmp|Portable Network Grahics (*.png)|*.png|JPEG (*.jpg)|*.jpg";

            if (ofd.ShowDialog() == true)
            {
                Image.Source = new BitmapImage(new Uri(ofd.FileName));
                imageIsLoaded = true;
            }
        }
    }
}
