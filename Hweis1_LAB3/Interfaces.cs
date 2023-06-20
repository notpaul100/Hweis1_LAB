using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDIDrawer;

namespace Hweis1_LAB3
{
    public interface IRender
    {
        void Render(CDrawer _canvas);
    }
    public interface IAnimate
    {
        void Tick();
    }
}
