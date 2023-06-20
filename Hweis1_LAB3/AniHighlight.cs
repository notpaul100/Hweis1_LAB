using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDIDrawer;

namespace Hweis1_LAB3
{
    class AniHighlight : AniChild
    {
        public AniHighlight(Color _c, int _disp, Shape _par, double _offset, double _delta = 0.1) 
            : base(_c,new PointF(_par._position.X, _par._position.Y), _par, _offset, _delta)
        {
        }

        public override void Render(CDrawer _canvas)
        {
            Point temp = new Point((int)_position.X, (int)_position.Y);
            //_canvas.AddCenteredRectangle(temp.X, temp.Y, 50, 50, Color.Empty, 2, Color.Fuchsia);
            _canvas.AddPolygon((int)(temp.X-40),(int)(temp.Y-40), 40, 4, base._sequence, Color.Empty, 7, Color.Fuchsia);
            Tick();
            base.Render(_canvas);
        }
    }
}
