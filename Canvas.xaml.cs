using System;
using System.Collections;
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
    /// Interaktionslogik für Canvas.xaml
    /// </summary>
    public partial class Canvas : Grid
    {
        public ArrayList PainterList;

        public Image ActualImage
        {
            get; private set;
        }

        public Canvas()
        {
            InitializeComponent();
            PainterList = new ArrayList();
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            foreach (Painter p in PainterList) 
            {
                // Zeichnen
                
                
                
            }
        }

        public void AddPainter(Painter p)
        {
            PainterList.Add(p);
            
            this.ActualDrawingCanvas.Children.Add(p);

           // Dispatcher.Invoke(() => InvalidateVisual());
        }
    }
}
