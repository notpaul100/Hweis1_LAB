using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;

namespace Hweis1_LAB3
{
    abstract class Shape : IRender
    {
        public Color _color;
        public PointF _position;
        public Shape _parent;
        public Shape(Color _c, PointF _poi, Shape _par)
        {
            _color = _c;
            _position = _poi;
            _parent = _par;
        }

        virtual public void Render(CDrawer _canvas)
        {
            if(_parent != null)     
                _canvas.AddLine((int)_position.X, (int)_position.Y, (int)_parent._position.X, (int)_parent._position.Y);
        }

    }
}
