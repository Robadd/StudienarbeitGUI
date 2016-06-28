using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Studienarbeit
{
    class WalkDirectional : IWalk
    {
        int dX;
        public int DX
        {
            get { return dX; }
            set { dX = value; }
        }

        int dY;
        public int DY
        {
            get { return dY; }
            set { dY = value; }
        }

        public WalkDirectional(int dx, int dy)
        {
            DY = dy;
            DX = dx;
        }

        public Point PositionChange() 
        {
            return new Point(DX,DY);
        }

        public void Reflect(ReflectionType reflType) 
        {
            if (reflType == ReflectionType.Bottom || reflType == ReflectionType.Top) DY = -DY;
            else if (reflType == ReflectionType.Left || reflType == ReflectionType.Right) DX = -DX;
        }

        public IBehaviour Clone()
        {
            return new WalkDirectional(DX,DY);
        }

        public Visual GetFace(Size size)
        {
            // Code einfügen
            DrawingVisual dv = new DrawingVisual();
            DrawingContext dc = dv.RenderOpen();

            //dc.PushTransform(new ScaleTransform(size.Width, size.Height));
            // HIER MALEN !!!! auf dc
            dc.DrawLine(new Pen(Brushes.CornflowerBlue,2),new Point(0,size.Height),new Point(0.1 * size.Width,0.9*size.Height));


            //dc.Pop();
            dc.Close();
            return dv;
        }

        public void ShowPropsDialog()
        {
            // !!!ToDO Eingestellte Werte übernehmen
            QuerEigWindow querEigWindow = new QuerEigWindow();
            querEigWindow.ShowDialog();
        }
    }
}
