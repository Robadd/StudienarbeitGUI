using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;

namespace Studienarbeit
{
    public class PaintSpray : IPaint
    {
        private Color sprayColor;
        public Color SprayColor
        {
            get { return sprayColor; }
            set { sprayColor = value; }
        }

        private Size spraySize;
        public Size SpraySize
        {
            get { return spraySize; }
            set { spraySize = value; }
        }

        public PaintSpray(Color SprayColor, Size SpraySize)
        {
            this.SprayColor = SprayColor;
            this.SpraySize = SpraySize;
        }

        public void PaintOn(DrawingContext dc, Size dcSize)
        {
            dc.DrawEllipse(new SolidColorBrush(SprayColor) , null, new Point(0, 0), dcSize.Width, dcSize.Height);
        }
        public IBehaviour Clone()
        {
            return new PaintSpray(SprayColor, SpraySize);
        }

        public Visual GetFace(Size size)
        {
            DrawingVisual dv = new DrawingVisual();
            using (DrawingContext dc = dv.RenderOpen())
            {
                dc.PushTransform(new ScaleTransform(size.Width, size.Height));
                /*
                Pen pen = new Pen(Brushes.Green, 0.5);
                StreamGeometry streamGeometry = new StreamGeometry();
                using (StreamGeometryContext geometryContext = streamGeometry.Open())
                {
                    geometryContext.BeginFigure(new Point(0, 0), true, true);
                    PointCollection points = new PointCollection { new Point(0.7, 1), new Point(1, 0.7) };
                    geometryContext.PolyLineTo(points, true, true);
                }
                dc.DrawGeometry(Brushes.Red, new Pen(Brushes.Black, 0.05), streamGeometry);
                 * */
                dc.Pop();
                dc.DrawImage(new System.Windows.Media.Imaging.BitmapImage(new Uri("pack://application:,,,/img/Scrat.png")), new Rect(0, 0, 1, 1));
                dc.Close();
            }
            return dv;
        }


        public void ShowPropsDialog()
        {
            SprayerEigWindow sprayerEigWindow = new SprayerEigWindow();
            sprayerEigWindow.Col = SprayColor;
            sprayerEigWindow.Breite = (int)SpraySize.Width;
            sprayerEigWindow.Hoehe = (int)SpraySize.Height;

            if (sprayerEigWindow.ShowDialog() == true)
            {
                this.SprayColor = sprayerEigWindow.Col;
                this.SpraySize = new Size(sprayerEigWindow.Breite, sprayerEigWindow.Hoehe);
            }
        }
    }

    



}
