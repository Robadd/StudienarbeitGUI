using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Studienarbeit
{
    class WalkRectangular : IWalk
    {
        private int pos;

        int dPos;
        public int DPos
        {
            get { return dPos; }
            set { dPos = value; }
        }

        int posLimRight;
        public int PosLimRight
        {
            get { return posLimRight; }
            set { posLimRight = value; }
        }

        int posLimLeft;
        public int PosLimLeft
        {
            get { return posLimLeft; }
            set { posLimLeft = value; }
        }

        int posLimDown;
        public int PosLimDown
        {
            get { return posLimDown; }
            set { posLimDown = value; }
        }

        int posLimUp;
        public int PosLimUp
        {
            get { return posLimUp; }
            set { posLimUp = value; }
        }

        DirType dir;
        public DirType Dir
        {
            get { return dir; }
            set { dir = value; }
        }

        public WalkRectangular(int posLimRight, int posLimLeft, int posLimUp, int posLimDown, int dPos, DirType dir)
        {
            Dir = dir;
            DPos = dPos;
            PosLimRight = posLimRight;
            PosLimLeft = posLimLeft;
            PosLimDown = posLimDown;
            PosLimUp = posLimUp;
        }

        public Point PositionChange()
        {
            pos += DPos;

            // Test auf Richtungsumkehrungsbedingung
            if (Dir == DirType.Right)
            {
                if (pos > PosLimRight)
                {
                    Dir = DirType.Down;
                    pos = 0;
                }
                return new Point(DPos, 0);
            }
            else if (Dir == DirType.Down)
            {
                if (pos > PosLimDown)
                {
                    Dir = DirType.Left;
                    pos = 0;
                }
                return new Point(0, DPos);
            }
            else if (Dir == DirType.Left)
            {
                if (pos > PosLimLeft)
                {
                    Dir = DirType.Up;
                    pos = 0;
                }
                return new Point(-DPos, 0);
            }
            else
            {
                if (pos > PosLimUp)
                {
                    Dir = DirType.Right;
                    pos = 0;
                }
                return new Point(0, -DPos);
            }
        }

        public void Reflect(ReflectionType reflType)
        {
            if (reflType == ReflectionType.Bottom || reflType == ReflectionType.Top)
            {
                int temp = PosLimDown;
                PosLimDown = PosLimUp;
                PosLimUp = temp;
                if (Dir == DirType.Down)
                    Dir = DirType.Up;
                else
                    Dir = DirType.Down;
            }
            else if (reflType == ReflectionType.Left || reflType == ReflectionType.Right)
            {
                int temp = PosLimRight;
                PosLimRight = PosLimLeft;
                PosLimLeft = temp;
                if (Dir == DirType.Left)
                    Dir = DirType.Right;
                else
                    Dir = DirType.Left;
            }
        }

        public IBehaviour Clone()
        {
            return new WalkRectangular(PosLimRight, PosLimLeft, PosLimUp, PosLimDown, DPos, Dir);
        }

        public Visual GetFace(Size size)
        {
            DrawingVisual dv = new DrawingVisual();
            DrawingContext dc = dv.RenderOpen();

            dc.DrawLine(new Pen(Brushes.CornflowerBlue, 2), new Point(0, size.Height), new Point(0.1 * size.Width, 0.9 * size.Height));
            dc.Close();

            return dv;
        }

        public void ShowPropsDialog()
        {
            RechtEigWindow rechtEigWindow = new RechtEigWindow();
            rechtEigWindow.LeftLimit = PosLimLeft;
            rechtEigWindow.RightLimit = PosLimRight;
            rechtEigWindow.UpLimit = PosLimUp;
            rechtEigWindow.DownLimit = PosLimUp;
            rechtEigWindow.Versatz = DPos;
            string dir;
            if (Dir == DirType.Right)
                dir = "Rechts";
            else if (Dir == DirType.Left)
                dir = "Links";
            else if (Dir == DirType.Up)
                dir = "Hinauf";
            else
                dir = "Hinunter";
            rechtEigWindow.Startrichtung = dir;

            if (rechtEigWindow.ShowDialog() == true)
            {
                DPos = rechtEigWindow.Versatz;

                dir = rechtEigWindow.Startrichtung;
                if (dir == "Rechts")
                    Dir = DirType.Right;
                else if (dir == "Links")
                    Dir = DirType.Left;
                else if (dir == "Hinauf")
                    Dir = DirType.Up;
                else if (dir == "Hinunter")
                    Dir = DirType.Down;


                PosLimLeft = rechtEigWindow.LeftLimit;
                PosLimRight = rechtEigWindow.RightLimit;
                PosLimUp = rechtEigWindow.UpLimit;
                PosLimDown = rechtEigWindow.DownLimit;

            }
        }
    }

    public enum DirType { Right, Down, Left, Up }
}
