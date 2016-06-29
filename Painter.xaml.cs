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
    /// Interaktionslogik für Painter.xaml
    /// </summary>
    public partial class Painter : UserControl
    {
        // Anzeigegröße des Painters, quasi static
        public Size size = new Size(50,50);
        // Malgröße
        public Size dcSize;

        private Point position;
        // bool Active;
        private IPaint paintType;
        public IPaint PaintType
        {
            get { return paintType; }
            set { paintType = value; }
        }

        private IWalk walkType;
        public IWalk WalkType
        {
            get { return walkType; }
            set { walkType = value; }
        }

        public Painter(IPaint paint, IWalk walk)
        {
            InitializeComponent();
            this.Height = size.Height;
            this.Width = size.Width;
            WalkType = walk;
            PaintType = paint;
            VisualBrush WalkBrush = new VisualBrush(WalkType.GetFace(size));
            VisualBrush DrawBrush = new VisualBrush(PaintType.GetFace(size));

            walker.Fill = WalkBrush;
            drawer.Fill = DrawBrush;

            //AddVisualChild(PaintType.GetFace(new Size(20,20)));
            //AddVisualChild(WalkType.GetFace(new Size(20,20)));
            this.Loaded += Window_Loaded;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //this.Height = MinVal;
            //this.Width = MaxVal;
        }

        public Point AdvancePosition()
        {
            Point verschiebung = WalkType.PositionChange();
            position.Offset(verschiebung.X,verschiebung.Y);
            return position;
        }

        public void setStartPos(Point pos)
        {
            position = pos;
        }

        public void PaintOn(DrawingContext dc)
        {
            if (PaintType is PaintSpray)
            {
                PaintType.PaintOn(dc, ((PaintSpray)PaintType).SpraySize);
            }
            else 
            {
                PaintType.PaintOn(dc, size);
            }
            
        }

        public void Reflect(ReflectionType reflType)
        {
            WalkType.Reflect(reflType);
        }
        
    }
}
