using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDIDrawer;

namespace Hweis1_LAB3
{
    class AniChild : AniShape
    {
        public double _distance;
        public AniChild(Color _c, PointF _poi, Shape _par, double _offset, double _delta = 0.1) 
            : base(_c, _poi, _par, _offset, _delta)
        {
            if(_par.Equals(null))
            {
                throw new ArgumentException("Parent is NULL"); 
            }
            _distance = Math.Sqrt(Math.Pow((_poi.X - _par._position.X), 2) 
                + Math.Pow((_poi.Y - _par._position.Y), 2));
        }
    }
}
