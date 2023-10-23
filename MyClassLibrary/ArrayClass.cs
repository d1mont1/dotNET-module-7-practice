using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLibrary
{
    public class ArrayClass
    {
        private int[] array;

        public ArrayClass(int[] values)
        {
            array = values;
        }

        public static bool operator <(ArrayClass a, ArrayClass b)
        {
            int sumA = a.array.Sum();
            int sumB = b.array.Sum();
            return sumA < sumB;
        }

        public static bool operator >(ArrayClass a, ArrayClass b)
        {
            int sumA = a.array.Sum();
            int sumB = b.array.Sum();
            return sumA > sumB;
        }
    }

}
