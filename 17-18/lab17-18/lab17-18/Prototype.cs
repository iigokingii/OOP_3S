using System;
using System.Collections.Generic;
using System.Text;

namespace lab17_18
{
    interface IFigure
    {
        void GetInfo();
        IFigure Clone();
    }
}
