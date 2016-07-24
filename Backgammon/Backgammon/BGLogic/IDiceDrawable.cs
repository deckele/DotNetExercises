using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgammon
{
    public interface IDiceDrawable
    {
        void Display(object obj, StateChangedEventArgs args);
    }
}
