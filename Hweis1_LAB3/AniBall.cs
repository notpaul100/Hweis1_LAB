using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDIDrawer;

namespace Hweis1_LAB3
{
    class AniBall : AniChild
    {
        private int size = 20;
        public AniBall(Color _c, PointF _poi, Shape _par, double _offset, double _delta = 0.1) 
            : base(_c, _poi, _par, _offset, _delta)
        {

        }

        public override void Render(CDrawer _canvas)
        {
            base.Render(_canvas);
            _canvas.AddCenteredEllipse((int)this._position.X, (int)this._position.Y, 20, 20,  this._color);
        }
    }
}
