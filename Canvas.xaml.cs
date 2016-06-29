using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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
        public Timer timer = new Timer(50);
        public ArrayList PainterList;
        public Size PainterSize = new Size(100,100);
        private int ttl=0;
        private bool sizeChangeInvalidate = false;

        private Image actualImage;
        public Image ActualImage
        {
            get { return actualImage; } 
            private set { actualImage = value; }
        }

        public Canvas()
        {
            InitializeComponent();

            PainterList = new ArrayList();
            ActualImage = new Image();

            timer.Elapsed += timer_Elapsed;
            timer.Start();   
        }

        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            sizeChangeInvalidate = false;
            Dispatcher.Invoke(() => InvalidateVisual());
        }

        void clean() 
        {
            ttl = 0;
            System.GC.Collect();
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            if (!sizeChangeInvalidate)
            {
                ttl++;
                if (ttl > 100) clean();
                double width = Math.Floor(this.ActualWidth);
                double height = Math.Floor(this.ActualHeight);

                // dv ist neues Bild, ums als actualImage abspeichern zu können
                DrawingVisual dv = new DrawingVisual();
                using (DrawingContext dc = dv.RenderOpen())
                {
                    // image holen und Als Hintergrund für dc setzen
                    dc.DrawImage(ActualImage.Source, new Rect(0, 0, width, height));

                    // Alle Painter drauf malen lassen
                    foreach (Painter p in PainterList)
                    {
                        // Punkt neu Positionieren
                        Point newPos;

                        // weitergehen
                        newPos = p.AdvancePosition();

                        //Am Rand reflektieren
                        if (newPos.Y < 0)
                        { 
                            p.Reflect(ReflectionType.Top);
                            newPos.Y = 0;
                        }
                        else if (newPos.Y > height)
                        { 
                            p.Reflect(ReflectionType.Bottom);
                            newPos.Y = height;
                        }
                        else if (newPos.X < 0)
                        { 
                            p.Reflect(ReflectionType.Left);
                            newPos.X = 0;
                        }
                        else if (newPos.X > width)
                        { 
                            p.Reflect(ReflectionType.Right);
                            newPos.X = width;
                        }

                        // Punkt zeichnen
                        dc.PushTransform(new TranslateTransform(Math.Floor(newPos.X), Math.Floor(newPos.Y)));
                        p.PaintOn(dc);
                        dc.Pop();

                        // Painter-Faces draufzeichnen
                        p.Margin = new Thickness(Math.Floor(newPos.X), Math.Floor(newPos.Y), 0, 0);
                    }
                }

                // DrawingContext als actualImage abspeichern
                RenderTargetBitmap bmp = new RenderTargetBitmap((int)width, (int)height, 96, 96, PixelFormats.Pbgra32);
                bmp.Render(dv);
                ActualImage.Source = bmp;
                drawingContext.DrawImage(ActualImage.Source, new Rect(0, 0, width, height));

                sizeChangeInvalidate = true;
            }
            else
            {
                ActualImage = new Image();
            }
        }

        public void AddPainter(Painter p)
        {
            PainterList.Add(p);
            p.size = PainterSize;
            p.HorizontalAlignment = HorizontalAlignment.Left;
            p.VerticalAlignment = VerticalAlignment.Top;
            this.Children.Add(p);
        }

        private void ActualDrawingCanvas_SizeChanged_1(object sender, SizeChangedEventArgs e)
        {
            sizeChangeInvalidate = true;
            Dispatcher.Invoke(() => InvalidateVisual());
        } 
    }
}
