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
using System.Windows.Forms;

namespace Studienarbeit
{
    /// <summary>
    /// Interaktionslogik für SprayerEigWindow.xaml
    /// </summary>
    public partial class SprayerEigWindow : Window
    {
        public SprayerEigWindow()
        {
            InitializeComponent();
        }

        public Color Col
        {
            get { return ((SolidColorBrush)color.Fill).Color; }
            set { color.Fill = new SolidColorBrush(value); }
        }

        public int Breite
        {
            get { return WidthValue.ActualValue; }
            set { WidthValue.ActualValue = value; }
        }

        public int Hoehe
        {
            get { return HeightValue.ActualValue; }
            set { HeightValue.ActualValue = value; }
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            this.Close();
        }

        private void Abbruch_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }

        private void FarbAusw_Click(object sender, RoutedEventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            
            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Col = Color.FromRgb(colorDialog.Color.R, colorDialog.Color.G, colorDialog.Color.B);
            }
        }
    }
}
