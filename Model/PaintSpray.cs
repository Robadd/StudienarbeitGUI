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

        public PaintSpray(Color SprayColor,Size SpraySize)
        {
            this.SprayColor = SprayColor;
            this.SpraySize = SpraySize;
        }
        
        public void PaintOn(DrawingContext dc, Size dcSize)
        {
            // Code einfügen
            dc.DrawEllipse(Brushes.Black, null, new Point(0, 0), dcSize.Width / 2, dcSize.Height / 2);
            
        }
        public IBehaviour Clone()
        {
            return new PaintSpray(SprayColor, SpraySize);
        }

        
        public Visual GetFace(Size size)
        {
            // Code einfügen
            DrawingVisual dv = new DrawingVisual();
            DrawingContext dc = dv.RenderOpen();
            dc.PushTransform(new ScaleTransform(size.Width,size.Height));
            // HIER MALEN !!!! auf dc 0-1, 0-1
            Pen pen = new Pen(Brushes.Green,0.5);
            StreamGeometry streamGeometry = new StreamGeometry();
            using (StreamGeometryContext geometryContext = streamGeometry.Open())
            {
                geometryContext.BeginFigure(new Point(0,0), true, true);
                PointCollection points = new PointCollection {new Point(0.7,1), new Point(1,0.7) };
                geometryContext.PolyLineTo(points, true, true);
            }
            //streamGeometry.Freeze();
            dc.DrawGeometry(Brushes.Red, new Pen(Brushes.Black, 0.05), streamGeometry);
            dc.Pop();
            
            

            dc.Close();
            return dv;
        }

        public void ShowPropsDialog()
        {
            // !!!ToDO Eingestellte Werte übernehmen
            SprayerEigWindow sprayerEigWindow = new SprayerEigWindow();
            sprayerEigWindow.ShowDialog();
        }
        
    }

    



}
