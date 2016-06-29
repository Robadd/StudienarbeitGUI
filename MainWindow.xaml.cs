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

namespace Studienarbeit
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MalEig_Click(object sender, RoutedEventArgs e)
        {
            if (Malarten.SelectedIndex == 0) //=Image
            {
                if (Maler.SelectedItem != null)
                {
                    PaintImage pi = (PaintImage)Maler.SelectedItem;
                    pi.ShowPropsDialog();
                }
            }

            else if (Malarten.SelectedIndex == 1) // =Sprayer
            {
                if (Maler.SelectedItem != null)
                {
                    PaintSpray ps = (PaintSpray)Maler.SelectedItem;
                    ps.ShowPropsDialog();
                }
            }
        }

        private void BewEig_Click(object sender, RoutedEventArgs e)
        {
            // !! Überarbeiten ShowPropsDialog Methode aufrufen
            if (BewArten.SelectedIndex == 0) // =Querfeldein
            {
                QuerEigWindow querEigWindow = new QuerEigWindow();
                querEigWindow.Show();
            }
            else if (BewArten.SelectedIndex == 1) // =Rechteck
            {
                RechtEigWindow rechtEigWindow = new RechtEigWindow();
                rechtEigWindow.Show();
            }
            
            if (BewArten.SelectedIndex == 0) //=Image
            {
                if (Maler.SelectedItem != null)
                {
                    PaintImage pi = (PaintImage)Maler.SelectedItem;
                    pi.ShowPropsDialog();
                }
            }

            else if (BewArten.SelectedIndex == 1) // =Sprayer
            {
                if (Maler.SelectedItem != null)
                {
                    PaintSpray ps = (PaintSpray)Maler.SelectedItem;
                    ps.ShowPropsDialog();
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Malarten Initialisierung
            Malarten.Items.Add("Image");
            Malarten.Items.Add("Sprayer");

            Malarten.SelectedIndex = 1;
            //ENDE Malarten Initialisierung

            //Bewegungsarten Initialisierung
            BewArten.Items.Add("Querfeldein");
            BewArten.Items.Add("Rechteck");

            BewArten.SelectedIndex = 0;
            //ENDE Bewegungsarten Initialisierung 
        }

        private void NeuerMaler_Click(object sender, RoutedEventArgs e)
        {
            IPaint paint = null;
            IWalk walk = null;

            // Momentan noch statische Werte
            // Evtl. die Maleigenschaften, die hier gebraucht werden als Variablen von dieser WindowKlasse setzen
            if (Malarten.SelectedIndex == 0) paint = new PaintImage(new Image());
            else if (Malarten.SelectedIndex == 1) paint = new PaintSpray(Colors.Black, new Size(2, 2));
            if (BewArten.SelectedIndex == 0) walk = new WalkDirectional(7, 3);
            else if (BewArten.SelectedIndex == 1) walk = new WalkRectangular(10, 7, 20, 8, 2, DirType.Up);

            Painter newPainter = new Painter(paint, walk);
            newPainter.setStartPos(new Point(0, 0));
            if((paint != null) && (walk != null)) DrawingCanvas.AddPainter(newPainter);

            //Maler
        }
    }
}
