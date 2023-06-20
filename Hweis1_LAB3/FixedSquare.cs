using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;

namespace Hweis1_LAB3
{
    class FixedSquare : Shape
    {
        private int size = 20;
        public Color _color;
        public PointF _position;
        public Shape _parent;
        public FixedSquare(PointF _point, Color _c, Shape _par)
            :base(_c, _point, _par)
        {
            _color = _c;
            _position = _point;
            _parent = _par;
            
        }
        public override void Render(CDrawer _canvas)
        {
            base.Render(_canvas);
            _canvas.AddCenteredRectangle((int)_position.X, (int)_position.Y, size, size, _color);
        }
    }
}
