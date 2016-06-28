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
       
        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Abbruch_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void FarbAusw_Click(object sender, RoutedEventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            
            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.Windows.Media.Color c = Color.FromRgb(colorDialog.Color.R, colorDialog.Color.G, colorDialog.Color.B);
                color.Fill = new SolidColorBrush(c);
            }
        }
    }
}
