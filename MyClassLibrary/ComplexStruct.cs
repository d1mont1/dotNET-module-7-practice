using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace MyClassLibrary
{
    public struct ComplexStruct
    {
        public double Real { get; }
        public double Imaginary { get; }

        public ComplexStruct(double real, double imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }

        public static ComplexStruct operator +(ComplexStruct a, ComplexStruct b)
        {
            return new ComplexStruct(a.Real + b.Real, a.Imaginary + b.Imaginary);
        }

        public static ComplexStruct operator -(ComplexStruct a, ComplexStruct b)
        {
            return new ComplexStruct(a.Real - b.Real, a.Imaginary - b.Imaginary);
        }

        public static ComplexStruct operator *(ComplexStruct a, ComplexStruct b)
        {
            return new ComplexStruct(a.Real * b.Real - a.Imaginary * b.Imaginary, a.Real * b.Imaginary + a.Imaginary * b.Real);
        }

        public static ComplexStruct operator /(ComplexStruct a, ComplexStruct b)
        {
            double denominator = b.Real * b.Real + b.Imaginary * b.Imaginary;
            return new ComplexStruct((a.Real * b.Real + a.Imaginary * b.Imaginary) / denominator, (a.Imaginary * b.Real - a.Real * b.Imaginary) / denominator);
        }

        public override string ToString()
        {
            return $"{Real} + {Imaginary}i";
        }

        public override bool Equals(object obj)
        {
            if (obj is ComplexStruct other)
            {
                return Real == other.Real && Imaginary == other.Imaginary;
            }
            return false;
        }

        public static bool operator ==(ComplexStruct a, ComplexStruct b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(ComplexStruct a, ComplexStruct b)
        {
            return !a.Equals(b);
        }

        public static explicit operator ComplexStruct(double v)
        {
            throw new NotImplementedException();
        }
    }

    [MemoryDiagnoser]
    public class ComplexStructBenchmarks
    {
        private ComplexStruct[] complexNumbers;

        [Params(1000)]
        public int N;

        [GlobalSetup]
        public void GlobalSetup()
        {
            complexNumbers = new ComplexStruct[N];
            var random = new Random();
            for (int i = 0; i < N; i++)
            {
                complexNumbers[i] = new ComplexStruct(random.NextDouble(), random.NextDouble());
            }
        }

        [Benchmark]
        public ComplexStruct SumComplexNumbers()
        {
            ComplexStruct sum = new ComplexStruct(0, 0);
            for (int i = 0; i < N; i++)
            {
                sum += complexNumbers[i];
            }
            return sum;
        }
    }
}
