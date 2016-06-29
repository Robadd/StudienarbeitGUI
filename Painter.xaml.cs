using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Studienarbeit
{
    /// <summary>
    /// Interaktionslogik für Painter.xaml
    /// </summary>
    public partial class Painter : UserControl
    {
        // Anzeigegröße des Painters, quasi static
        public Size size = new Size(50, 50);

        private Point position;

        // Malpunktgröße
        public Size dcSize;

        public String name;
        public override string ToString()
        {
            return name;
        }

        public bool Active;

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
        }

        public Point AdvancePosition()
        {
            Point verschiebung = WalkType.PositionChange();
            position.Offset(verschiebung.X, verschiebung.Y);
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
