using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gumar_5_17._10._19
{
    public class DataTipes<T>
    {
        public DataTipes(T[] data)
        {
            this.data = data;
        }

        T[] data;

        public IEnumerator GetEnumerator()
        {
            foreach(T d in data)
            {
                yield return d;
            }


        }
    }
}
