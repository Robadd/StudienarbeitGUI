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
    /// Interaktionslogik für RechtEigWindow.xaml
    /// </summary>
    public partial class RechtEigWindow : Window
    {
        public RechtEigWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //StartRich Combobox Initialisierung
            StartRich.Items.Add("Rechts");
            StartRich.Items.Add("Links");
            StartRich.Items.Add("Hinunter");
            StartRich.Items.Add("Hinauf");

            StartRich.SelectedIndex = 0;
            //ENDE StartRich Combobox Initialisierung
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Abbruch_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
