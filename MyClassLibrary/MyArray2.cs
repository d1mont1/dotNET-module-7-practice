using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLibrary
{
    public class MyArray2
    {
        private int[] data;

        public MyArray2(int size)
        {
            data = new int[size];
        }

        public int Length => data.Length;

        public int this[int index]
        {
            get
            {
                if (index >= 0 && index < data.Length)
                {
                    return data[index];
                }
                throw new IndexOutOfRangeException("Index is out of range.");
            }
            set
            {
                if (index >= 0 && index < data.Length)
                {
                    data[index] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("Index is out of range.");
                }
            }
        }

        public static bool operator ==(MyArray2 arr1, MyArray2 arr2)
        {
            if (ReferenceEquals(arr1, arr2))
            {
                return true;
            }
            if ((arr1 is null) || (arr2 is null))
            {
                return false;
            }

            if (arr1.Length != arr2.Length)
            {
                return false;
            }

            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] != arr2[i])
                {
                    return false;
                }
            }
            return true;
        }

        public static bool operator !=(MyArray2 arr1, MyArray2 arr2)
        {
            return !(arr1 == arr2);
        }

        public static MyArray2 operator +(MyArray2 arr1, MyArray2 arr2)
        {
            if (arr1.Length != arr2.Length)
            {
                throw new InvalidOperationException("Arrays must have the same length for addition.");
            }

            MyArray2 result = new MyArray2(arr1.Length);
            for (int i = 0; i < arr1.Length; i++)
            {
                result[i] = arr1[i] + arr2[i];
            }

            return result;
        }
    }

}
