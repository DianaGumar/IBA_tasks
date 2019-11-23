using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gumar_5_17._10._19
{
    public interface Iterator
    {
        int First();
        int Next();
        bool IsDone();
        int CurrentItem();



    }
}
