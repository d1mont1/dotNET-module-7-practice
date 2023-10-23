using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLibrary
{
    public class MyClass
    {
        public int Prop1 { get; set; }
        public string Prop2 { get; set; }

        public MyClass(int prop1, string prop2)
        {
            Prop1 = prop1;
            Prop2 = prop2;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            MyClass other = (MyClass)obj;
            return Prop1 == other.Prop1 && Prop2 == other.Prop2;
        }

        public override int GetHashCode()
        {
            return Prop1.GetHashCode() ^ Prop2.GetHashCode();
        }

        public static bool operator ==(MyClass a, MyClass b)
        {
            if (ReferenceEquals(a, b))
            {
                return true;
            }

            if (a is null || b is null)
            {
                return false;
            }

            return a.Equals(b);
        }

        public static bool operator !=(MyClass a, MyClass b)
        {
            return !(a == b);
        }
    }

}
