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

        public int LeftLimit
        {
            get { return Left.ActualValue; }
            set { Left.ActualValue = value; }
        }
        public int RightLimit
        {
            get { return Right.ActualValue; }
            set { Right.ActualValue = value; }
        }
        public int UpLimit
        {
            get { return Up.ActualValue; }
            set { Up.ActualValue = value; }
        }
        public int DownLimit
        {
            get { return Down.ActualValue; }
            set { Down.ActualValue = value; }
        }

        public int Versatz
        {
            get { return Vers.ActualValue; }
            set { Vers.ActualValue = value; }
        }

        public string Startrichtung
        {
            get { return StartRich.SelectedItem.ToString(); }
            set { StartRich.SelectedItem = value; }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //StartRich Combobox Initialisierung
            StartRich.Items.Add("Rechts");
            StartRich.Items.Add("Links");
            StartRich.Items.Add("Hinunter");
            StartRich.Items.Add("Hinauf");

            StartRich.SelectedIndex = 0;
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


    }
}
