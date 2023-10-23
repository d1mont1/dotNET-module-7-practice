using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace MyClassLibrary
{
    public class FracClass
    {
        public int Numerator { get; set; }
        public int Denominator { get; set; }

        public FracClass(int numerator, int denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
        }

        public static FracClass operator +(FracClass a, FracClass b)
        {
            int commonDenominator = LCM(a.Denominator, b.Denominator);
            int newNumerator = (a.Numerator * (commonDenominator / a.Denominator)) + (b.Numerator * (commonDenominator / b.Denominator));
            return new FracClass(newNumerator, commonDenominator);
        }

        public static FracClass operator -(FracClass a, FracClass b)
        {
            int commonDenominator = LCM(a.Denominator, b.Denominator);
            int newNumerator = (a.Numerator * (commonDenominator / a.Denominator)) - (b.Numerator * (commonDenominator / b.Denominator));
            return new FracClass(newNumerator, commonDenominator);
        }

        public static FracClass operator *(FracClass a, FracClass b)
        {
            return new FracClass(a.Numerator * b.Numerator, a.Denominator * b.Denominator);
        }

        public static FracClass operator /(FracClass a, FracClass b)
        {
            if (b.Numerator == 0)
            {
                throw new DivideByZeroException("Division by zero.");
            }
            return new FracClass(a.Numerator * b.Denominator, a.Denominator * b.Numerator);
        }

        public static implicit operator FracClass(int value)
        {
            return new FracClass(value, 1);
        }

        private static int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        private static int LCM(int a, int b)
        {
            return (a / GCD(a, b)) * b;
        }
    }

    [MemoryDiagnoser]
    public class FracClassBenchmarks
    {
        private FracClass[] fractions;
        private FracClass sum;

        [Params(1000)]
        public int N;

        [GlobalSetup]
        public void GlobalSetup()
        {
            fractions = new FracClass[N];
            var random = new Random();
            for (int i = 0; i < N; i++)
            {
                fractions[i] = new FracClass(random.Next(1, 100), random.Next(1, 100));
            }
            sum = new FracClass(0, 1);
        }

        [Benchmark]
        public FracClass SumFractions()
        {
            FracClass result = new FracClass(0, 1);
            for (int i = 0; i < N; i++)
            {
                result += fractions[i];
            }
            return result;
        }
    }
}
