using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;

namespace Hweis1_LAB3
{
    class AniPoly : AniShape
    {
        int _sideCount;
        public AniPoly(PointF _poi, Color _c, int _side, Shape _par, double _offset, double _delta = 0.1)
            : base(_c, _poi, _par, _offset, _delta)
        {
            if (_side < 3)
            {
                throw new ArgumentException("Sides are less than 3.");
            }
            else
            {
                _sideCount = _side;
            }
        }
        public override void Render(CDrawer _canvas)
        {
            base.Render(_canvas);
            Tick();
            _canvas.AddPolygon((int)base._position.X, (int)base._position.Y, 25 , _sideCount, base._sequence, base._color);
        }
    }
}
