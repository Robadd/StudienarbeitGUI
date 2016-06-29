using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
        //Malarten
        const string MALART_IMAGE = "Image";
        const string MALART_SPRAYER = "Sprayer";

        //Beweungsarten
        const string BEW_ART_QUER = "Querfeldein";
        const string BEW_ART_RECHTECK = "Rechteck";

        enum painterTypes { Sprayer, Image }
        enum walkTypes { Quer, Rechteck }

        //Standardwerte
        static PaintSpray PaintSprayStd = new PaintSpray(Colors.Black, new Size(3, 3));
        static PaintImage PaintImageStd = new PaintImage(new Image());

        static WalkDirectional WalkDirStd = new WalkDirectional(2, 2);
        static WalkRectangular WalkRecStd = new WalkRectangular(2, 2, 2, 2, 2, DirType.Right);




        class CMaler : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;

            protected void OnPropertyChanged(PropertyChangedEventArgs e)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null)
                    handler(this, e);
            }

            protected void OnPropertyChanged(string propertyName)
            {
                OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
            }

            string name;
            public string Name
            {
                get { return name; }
                set { name = value; OnPropertyChanged("Name"); }
            }

            bool aktiv;
            public bool Aktiv
            {
                get { return aktiv; }
                set { 
                    aktiv = value; 
                    OnPropertyChanged("Aktiv");
                    MyPainter.Active = value;
                }
            }

            Painter myPainter;
            public Painter MyPainter
            {
                get { return myPainter; }
                set { myPainter = value; }
            }
            
            painterTypes malart;
            public painterTypes Malart
            {
                get { return malart; }
                set
                {
                    if (malart != value)
                    {
                        malart = value;
                        if (malart == painterTypes.Sprayer) MyPainter.PaintType = PaintSprayStd;
                        else if (malart == painterTypes.Image) MyPainter.PaintType = PaintImageStd;
                    }
                }
            }

            walkTypes bewArt;
            public walkTypes BewArt
            {
                get { return bewArt; }
                set
                {
                    if (bewArt != value)
                    {
                        bewArt = value;
                        if (bewArt == walkTypes.Quer) MyPainter.WalkType = WalkDirStd;
                        else if (bewArt == walkTypes.Rechteck) MyPainter.WalkType = WalkRecStd;
                    }
                }
            }

            public CMaler(Painter painter)
            {
                MyPainter = painter;
                Name = "NeuerMaler";
                Aktiv = false;
                Malart = painterTypes.Sprayer;
                BewArt = walkTypes.Quer;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
        }


        private void MalEig_Click(object sender, RoutedEventArgs e)
        {
            if (Malarten.SelectedItem.ToString() == MALART_SPRAYER)
            {
                if (Maler.SelectedItem == null) return;

                ((PaintSpray)((CMaler)Maler.SelectedItem).MyPainter.PaintType).ShowPropsDialog();
            }
            else if (Malarten.SelectedItem.ToString() == MALART_IMAGE)
            {
                if (Maler.SelectedItem == null) return;
                ((PaintImage)((CMaler)Maler.SelectedItem).MyPainter.PaintType).ShowPropsDialog();
            }
        }

        private void BewEig_Click(object sender, RoutedEventArgs e)
        {
            if (BewArten.SelectedItem.ToString() == BEW_ART_QUER)
            {
                if (Maler.SelectedItem == null) return;
                ((WalkDirectional)((CMaler)Maler.SelectedItem).MyPainter.WalkType).ShowPropsDialog();
            }
            else if (BewArten.SelectedItem.ToString() == BEW_ART_RECHTECK)
            {
                if (Maler.SelectedItem == null) return;
                ((WalkRectangular)((CMaler)Maler.SelectedItem).MyPainter.WalkType).ShowPropsDialog();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Malarten Initialisierung
            Malarten.Items.Add(MALART_SPRAYER);
            Malarten.Items.Add(MALART_IMAGE);

            Malarten.SelectedItem = MALART_SPRAYER;

            //Bewegungsarten Initialisierung
            BewArten.Items.Add(BEW_ART_QUER);
            BewArten.Items.Add(BEW_ART_RECHTECK);

            BewArten.SelectedItem = BEW_ART_QUER;


            Malarten.IsEnabled = false;
            MalEig.IsEnabled = false;
            BewArten.IsEnabled = false;
            BewEig.IsEnabled = false;

            Name.Text = "";
            Name.IsEnabled = false;
            XPos.Text = "";
            XPos.IsEnabled = false;
            YPos.Text = "";
            YPos.IsEnabled = false;
        }

        private void NeuerMaler_Click(object sender, RoutedEventArgs e)
        {
            // Standard Painter
            Painter PainterStd = new Painter((IPaint)PaintSprayStd.Clone(), (IWalk)WalkDirStd.Clone());

            //Maler erstellen
            Maler.Items.Add(new CMaler(PainterStd));
            DrawingCanvas.AddPainter(((CMaler)Maler.Items.GetItemAt(Maler.Items.Count-1)).MyPainter);
        }

        private void Malarten_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Maler.SelectedItem == null) return;

            if (Malarten.SelectedItem.ToString() == MALART_SPRAYER)
                ((CMaler)Maler.SelectedItem).Malart = painterTypes.Sprayer;
            else if (Malarten.SelectedItem.ToString() == MALART_IMAGE)
                ((CMaler)Maler.SelectedItem).Malart = painterTypes.Image;
        }

        private void Maler_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Maler.SelectedItem == null)
            {
                Malarten.IsEnabled = false;
                MalEig.IsEnabled = false;
                BewArten.IsEnabled = false;
                BewEig.IsEnabled = false;

                Name.Text = "";
                Name.IsEnabled = false;
                XPos.Text = "";
                XPos.IsEnabled = false;
                YPos.Text = "";
                YPos.IsEnabled = false;
            }
            else
            {
                Malarten.IsEnabled = true;
                MalEig.IsEnabled = true;
                BewArten.IsEnabled = true;
                BewEig.IsEnabled = true;

                Name.Text = ((CMaler)Maler.SelectedItem).Name;
                Name.IsEnabled = true;
                XPos.Text = ((CMaler)Maler.SelectedItem).MyPainter.Margin.Left.ToString();
                XPos.IsEnabled = true;
                YPos.Text = ((CMaler)Maler.SelectedItem).MyPainter.Margin.Top.ToString();
                YPos.IsEnabled = true;


                //Malart selektieren
                if ( ((CMaler)Maler.SelectedItem).Malart.Equals(painterTypes.Sprayer) ) //if Malart == Sprayer
                    Malarten.SelectedItem = MALART_SPRAYER;
                else if (((CMaler)Maler.SelectedItem).Malart.Equals(painterTypes.Image)) //if Malart == Image
                    Malarten.SelectedItem = MALART_IMAGE;

                //Bewegungsart selektieren
                if (((CMaler)Maler.SelectedItem).BewArt.Equals(walkTypes.Quer)) //if BewArt == Quer
                    BewArten.SelectedItem = BEW_ART_QUER;
                else if (((CMaler)Maler.SelectedItem).BewArt.Equals(walkTypes.Rechteck)) //if BewArt == Rechteck
                    BewArten.SelectedItem = BEW_ART_RECHTECK;
            }
        }

        private void Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Maler.SelectedItem == null) return;

            ((CMaler)Maler.SelectedItem).Name = Name.Text;
        }

        private void BewArten_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Maler.SelectedItem == null) return;


            if (BewArten.SelectedItem.ToString() == BEW_ART_QUER)
                ((CMaler)Maler.SelectedItem).BewArt = walkTypes.Quer;
            else if (BewArten.SelectedItem.ToString() == BEW_ART_RECHTECK)
                ((CMaler)Maler.SelectedItem).BewArt = walkTypes.Rechteck;
        }

        private void MenuItem_Click_Neu(object sender, RoutedEventArgs e)
        {
            Maler.Items.Clear();
            DrawingCanvas.Clear();
        }

        private void MenuItem_Click_Beenden(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void XPos_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            int outX,outY;
            if (Maler.SelectedItem == null) return;
            if (int.TryParse(XPos.Text, out outX) && int.TryParse(YPos.Text, out outY))
            {
                ((CMaler)Maler.SelectedItem).MyPainter.setStartPos(new Point(outX, outY));
                Dispatcher.Invoke(() => InvalidateVisual());
            }
        }

        private void YPos_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            int outX, outY;
            if (Maler.SelectedItem == null) return;
            if (int.TryParse(XPos.Text, out outX) && int.TryParse(YPos.Text, out outY))
            {
                ((CMaler)Maler.SelectedItem).MyPainter.setStartPos(new Point(outX, outY));
                Dispatcher.Invoke(() => InvalidateVisual());
            }
        }

        private void MenuItem_Click_Save(object sender, RoutedEventArgs e)
        {

        }
    }
}
