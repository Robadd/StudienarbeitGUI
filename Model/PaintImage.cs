﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Controls;

namespace Studienarbeit
{
    public class PaintImage : IPaint
    {
        private Image image;
        public Image Image
        {
            get { return image; }
            set { image = value; }
        }

        public PaintImage(Image Image)
        {
            this.image = Image;
        }

        public void PaintOn(DrawingContext dc, Size dcSize)
        {
            dc.DrawImage(image.Source, new Rect(dcSize));
        }

        public IBehaviour Clone()
        {
            return new PaintImage(Image);
        }

        public Visual GetFace(Size size)
        {  
            DrawingVisual dv = new DrawingVisual();       
            DrawingContext dc = dv.RenderOpen();

            dc.DrawImage(image.Source, new Rect(0, 0, 0.5 * size.Width, 0.5 * size.Height));
            dc.DrawRectangle(null, new Pen(Brushes.Gray, 0.1), new Rect(0, 0, 0.5 * size.Width, 0.5 * size.Height));

            dc.Close();
            return dv;
        }

        public void ShowPropsDialog()
        {
            // !!!ToDO Eingestellte Werte übernehmen
            ImageEigWindow imageEigWindow = new ImageEigWindow();
            imageEigWindow.ShowDialog();
        }
    }
}
