using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Studienarbeit
{
    public enum ReflectionType
    {
        None, Left, Right, Top, Bottom
    }

    public interface IBehaviour
    {
        IBehaviour Clone();
        Visual GetFace(Size size);
        void ShowPropsDialog();
    }

    public interface IWalk : IBehaviour
    {
        Point PositionChange();
        void Reflect(ReflectionType reflType);
    }

    public interface IPaint : IBehaviour
    {
        void PaintOn(DrawingContext dc, Size dcSize);
    }
}
