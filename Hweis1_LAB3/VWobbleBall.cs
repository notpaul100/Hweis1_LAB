using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hweis1_LAB3
{
    class VWobbleBall : AniBall
    {
        public VWobbleBall(Color _c, int _disp, Shape _par, double _delta, double _offset = 0) 
            : base(_c, new PointF(_par._position.X, _par._position.Y - _disp), _par, _offset, _delta)
        {

        }

        public override void Tick()
        {
            this._position.X = _parent._position.X;
            this._position.Y = (float)(Math.Cos(this._sequence) * _distance + _parent._position.Y);
            base.Tick();
        }
    }
}
