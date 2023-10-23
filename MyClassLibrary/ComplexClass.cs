using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace MyClassLibrary
{
    public class ComplexClass
    {
        public double Real { get; set; }
        public double Imaginary { get; set; }

        public ComplexClass(double real, double imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }

        public static ComplexClass operator +(ComplexClass a, ComplexClass b)
        {
            return new ComplexClass(a.Real + b.Real, a.Imaginary + b.Imaginary);
        }

        public static ComplexClass operator -(ComplexClass a, ComplexClass b)
        {
            return new ComplexClass(a.Real - b.Real, a.Imaginary - b.Imaginary);
        }

        public static ComplexClass operator *(ComplexClass a, ComplexClass b)
        {
            return new ComplexClass(a.Real * b.Real - a.Imaginary * b.Imaginary, a.Real * b.Imaginary + a.Imaginary * b.Real);
        }

        public static ComplexClass operator /(ComplexClass a, ComplexClass b)
        {
            double denominator = b.Real * b.Real + b.Imaginary * b.Imaginary;
            return new ComplexClass((a.Real * b.Real + a.Imaginary * b.Imaginary) / denominator, (a.Imaginary * b.Real - a.Real * b.Imaginary) / denominator);
        }

        public static implicit operator ComplexClass(double real)
        {
            return new ComplexClass(real, 0);
        }

        public override string ToString()
        {
            return $"{Real} + {Imaginary}i";
        }

        public override bool Equals(object obj)
        {
            if (obj is ComplexClass other)
            {
                return Real == other.Real && Imaginary == other.Imaginary;
            }
            return false;
        }

        

        public static bool operator ==(ComplexClass a, ComplexClass b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(ComplexClass a, ComplexClass b)
        {
            return !a.Equals(b);
        }
    }

    [MemoryDiagnoser]
    public class ComplexClassBenchmarks
    {
        private ComplexClass[] complexNumbers;

        [Params(1000)]
        public int N;

        [GlobalSetup]
        public void GlobalSetup()
        {
            complexNumbers = new ComplexClass[N];
            var random = new Random();
            for (int i = 0; i < N; i++)
            {
                complexNumbers[i] = new ComplexClass(random.NextDouble(), random.NextDouble());
            }
        }

        [Benchmark]
        public ComplexClass SumComplexNumbers()
        {
            ComplexClass sum = new ComplexClass(0, 0);
            for (int i = 0; i < N; i++)
            {
                sum += complexNumbers[i];
            }
            return sum;
        }
    }
}
