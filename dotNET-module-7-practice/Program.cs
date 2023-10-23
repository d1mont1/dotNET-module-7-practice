using System;
using MyClassLibrary;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace dotNET_module_7_practice
{
    class Program
    {
        static void Main(string[] args)
        {
            //ЗАДАЧА №1
            Console.WriteLine("////////////////ЗАДАЧА №1////////////////");

            MyClass obj1 = new MyClass(1, "Hello");
            MyClass obj2 = new MyClass(1, "Hello");
            MyClass obj3 = new MyClass(2, "World");

            // Сравниваем объекты с использованием оператора ==
            bool areEqual1 = obj1 == obj2;  // Должно вернуть true
            bool areEqual2 = obj1 == obj3;  // Должно вернуть false

            // Сравниваем объекты с использованием оператора !=
            bool areNotEqual1 = obj1 != obj2;  // Должно вернуть false
            bool areNotEqual2 = obj1 != obj3;  // Должно вернуть true

            // Сравниваем объекты с использованием метода Equals
            bool areEqual3 = obj1.Equals(obj2);  // Должно вернуть true
            bool areEqual4 = obj1.Equals(obj3);  // Должно вернуть false

            Console.WriteLine("Сравнение с использованием оператора ==:");
            Console.WriteLine($"obj1 == obj2: {areEqual1}");
            Console.WriteLine($"obj1 == obj3: {areEqual2}");

            Console.WriteLine("\nСравнение с использованием оператора !=:");
            Console.WriteLine($"obj1 != obj2: {areNotEqual1}");
            Console.WriteLine($"obj1 != obj3: {areNotEqual2}");

            Console.WriteLine("\nСравнение с использованием метода Equals:");
            Console.WriteLine($"obj1.Equals(obj2): {areEqual3}");
            Console.WriteLine($"obj1.Equals(obj3): {areEqual4}");


            //ЗАДАЧА №2
            Console.WriteLine("\n\n////////////////ЗАДАЧА №2////////////////\n\n");


            ArrayClass array1 = new ArrayClass(new int[] { 1, 2, 3 });
            ArrayClass array2 = new ArrayClass(new int[] { 4, 5, 6 });

            if (array1 < array2)
            {
                Console.WriteLine("Сумма элементов в array1 меньше.");
            }
            else if (array1 > array2)
            {
                Console.WriteLine("Сумма элементов в array1 больше.");
            }
            else
            {
                Console.WriteLine("Сумма элементов в array1 равна сумме элементов в array2.");
            }


            ////ЗАДАЧА №3
            Console.WriteLine("\n\n////////////////ЗАДАЧА №3////////////////\n\n");


            Money money1 = new Money(100, "USD");
            Money money2 = new Money(200, "EUR");
            decimal exchangeRate = 0.85m; // Пример обменного курса (1 USD = 0.85 EUR)

            CurrencyConverter converter = new CurrencyConverter();
            converter.AddExchangeRate("USD", 1.0m);
            converter.AddExchangeRate("EUR", exchangeRate);

            money1 = converter.Convert(money1, "EUR");

            Money totalMoney = money1 + money2; // Теперь можно сложить, так как обе суммы в одной валюте (EUR)

            Console.WriteLine($"Total: {totalMoney.Amount} {totalMoney.Currency}");


            ////ЗАДАЧА №4
            Console.WriteLine("\n\n////////////////ЗАДАЧА №4////////////////\n\n");


            MyArray arr1 = new MyArray(3);
            arr1[0] = 1;
            arr1[1] = 2;
            arr1[2] = 3;

            MyArray arr2 = new MyArray(3);
            arr2[0] = 4;
            arr2[1] = 5;
            arr2[2] = 6;

            MyArray result = arr1 * arr2;
            Console.WriteLine("Multiplication Result:");
            for (int i = 0; i < result.Length; i++)
            {
                Console.Write(result[i] + " ");
            }
            Console.WriteLine();

            bool areEqual = (arr1 == arr2);
            Console.WriteLine("Equality: " + areEqual);

            bool lessOrEqual = arr1.LessOrEqual(arr2);
            Console.WriteLine("arr1 <= arr2: " + lessOrEqual);


            ////ЗАДАЧА №5
            Console.WriteLine("\n\n////////////////ЗАДАЧА №5////////////////\n\n");


            MyArray2 arrr1 = new MyArray2(3);
            arr1[0] = 1;
            arr1[1] = 2;
            arr1[2] = 3;

            MyArray2 arrr2 = new MyArray2(3);
            arr2[0] = 4;
            arr2[1] = 5;
            arr2[2] = 6;

            MyArray2 resultt = arrr1 + arrr2;
            Console.WriteLine("Addition Result:");
            for (int i = 0; i < result.Length; i++)
            {
                Console.Write(result[i] + " ");
            }
            Console.WriteLine();

            bool areEquall = (arr1 == arr2);
            Console.WriteLine("Equality: " + areEquall);

            bool notEquall = (arr1 != arr2);
            Console.WriteLine("Inequality: " + notEquall);


            ////ЗАДАЧА №6
            Console.WriteLine("\n\n////////////////ЗАДАЧА №6////////////////\n\n");


            Decimal num1 = new Decimal("12345");
            Decimal num2 = new Decimal("6789");

            Decimal sum = num1 + num2;
            Console.WriteLine("Sum: " + sum);

            Decimal difference = num1 - num2;
            Console.WriteLine("Difference: " + difference);

            Decimal product = num1 * num2;
            Console.WriteLine("Product: " + product);

            bool isEqual = num1 == num2;
            Console.WriteLine("Equality: " + isEqual);

            bool isNotEqual = num1 != num2;
            Console.WriteLine("Inequality: " + isNotEqual);


            ////ЗАДАЧА №7
            Console.WriteLine("\n\n////////////////ЗАДАЧА №7////////////////\n\n");

            var summary1 = BenchmarkRunner.Run<ComplexClassBenchmarks>();
            var summary2 = BenchmarkRunner.Run<ComplexStructBenchmarks>();


            ////ЗАДАЧА №8
            Console.WriteLine("\n\n////////////////ЗАДАЧА №8////////////////\n\n");

            var summary3 = BenchmarkRunner.Run<FracClassBenchmarks>();
            var summary4 = BenchmarkRunner.Run<FracStructtBenchmarks>();

        }
    }
}
