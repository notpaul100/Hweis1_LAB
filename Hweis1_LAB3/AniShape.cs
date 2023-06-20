using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;

namespace Hweis1_LAB3
{
    abstract class AniShape : Shape, IAnimate
    {
        public double _sequence;
        public double _tickDelta;
        public AniShape(Color _c, PointF _poi, Shape _par, double _offset, double _delta)
            :base(_c, _poi, _par)
        {
            _sequence = _offset;
            _tickDelta = _delta;
        }

        public virtual void Tick()
        {
            _sequence += _tickDelta;
        }
    }
}
