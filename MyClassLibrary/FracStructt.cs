using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace MyClassLibrary
{
    public struct FracStructt
    {
        public int Numerator { get; set; }
        public int Denominator { get; set; }

        public FracStructt(int numerator, int denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
        }

        public static FracStructt operator +(FracStructt a, FracStructt b)
        {
            int commonDenominator = LCM(a.Denominator, b.Denominator);
            int newNumerator = (a.Numerator * (commonDenominator / a.Denominator)) + (b.Numerator * (commonDenominator / b.Denominator));
            return new FracStructt(newNumerator, commonDenominator);
        }

        public static FracStructt operator -(FracStructt a, FracStructt b)
        {
            int commonDenominator = LCM(a.Denominator, b.Denominator);
            int newNumerator = (a.Numerator * (commonDenominator / a.Denominator)) - (b.Numerator * (commonDenominator / b.Denominator));
            return new FracStructt(newNumerator, commonDenominator);
        }

        public static FracStructt operator *(FracStructt a, FracStructt b)
        {
            return new FracStructt(a.Numerator * b.Numerator, a.Denominator * b.Denominator);
        }

        public static FracStructt operator /(FracStructt a, FracStructt b)
        {
            if (b.Numerator == 0)
            {
                throw new DivideByZeroException("Division by zero.");
            }
            return new FracStructt(a.Numerator * b.Denominator, a.Denominator * b.Numerator);
        }

        public static implicit operator FracStructt(int value)
        {
            return new FracStructt(value, 1);
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
    public class FracStructtBenchmarks
    {
        private FracStructt[] fractions;
        private FracStructt sum;

        [Params(1000)]
        public int N;

        [GlobalSetup]
        public void GlobalSetup()
        {
            fractions = new FracStructt[N];
            var random = new Random();
            for (int i = 0; i < N; i++)
            {
                fractions[i] = new FracStructt(random.Next(1, 100), random.Next(1, 100));
            }
            sum = new FracStructt(0, 1);
        }

        [Benchmark]
        public FracStructt SumFractions()
        {
            FracStructt result = new FracStructt(0, 1);
            for (int i = 0; i < N; i++)
            {
                result += fractions[i];
            }
            return result;
        }
    }
}
