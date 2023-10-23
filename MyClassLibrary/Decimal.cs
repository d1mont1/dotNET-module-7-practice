using System;

public class Decimal
{
    private char[] digits = new char[100];

    public Decimal(string value)
    {
        if (value.Length > 100)
        {
            throw new ArgumentException("Value is too large for Decimal representation.");
        }

        // Заполняем массив цифрами из строки (слева направо)
        int startIndex = 100 - value.Length;
        for (int i = 0; i < value.Length; i++)
        {
            digits[startIndex + i] = value[i];
        }
    }

    public override string ToString()
    {
        // Преобразовываем массив цифр обратно в строку
        int startIndex = Array.FindIndex(digits, c => c != '\0');
        if (startIndex == -1)
        {
            return "0";
        }
        return new string(digits, startIndex, 100 - startIndex);
    }

    public static Decimal operator +(Decimal a, Decimal b)
    {
        char[] result = new char[100];
        int carry = 0;

        for (int i = 99; i >= 0; i--)
        {
            int sum = a.digits[i] - '0' + b.digits[i] - '0' + carry;
            result[i] = (char)((sum % 10) + '0');
            carry = sum / 10;
        }

        return new Decimal(new string(result));
    }

    public static Decimal operator -(Decimal a, Decimal b)
    {
        char[] result = new char[100];
        int borrow = 0;

        for (int i = 99; i >= 0; i--)
        {
            int diff = a.digits[i] - '0' - (b.digits[i] - '0') - borrow;
            if (diff < 0)
            {
                diff += 10;
                borrow = 1;
            }
            else
            {
                borrow = 0;
            }
            result[i] = (char)(diff + '0');
        }

        return new Decimal(new string(result));
    }

    public static Decimal operator *(Decimal a, Decimal b)
    {
        Decimal product = new Decimal("0");

        for (int i = 99; i >= 0; i--)
        {
            Decimal partialProduct = new Decimal("0");
            int carry = 0;

            for (int j = 99; j >= 0; j--)
            {
                int productDigit = (a.digits[i] - '0') * (b.digits[j] - '0') + carry;
                partialProduct.digits[j] = (char)((productDigit % 10) + '0');
                carry = productDigit / 10;
            }

            // Сдвигаем partialProduct на правильную позицию и прибавляем к общему product
            int shift = 99 - i;
            for (int k = 99; k >= 0; k--)
            {
                if (k - shift >= 0)
                {
                    partialProduct.digits[k] = partialProduct.digits[k - shift];
                }
                else
                {
                    partialProduct.digits[k] = '0';
                }
            }
            product += partialProduct;
        }

        return product;
    }

    public static bool operator ==(Decimal a, Decimal b)
    {
        return a.ToString() == b.ToString();
    }

    public static bool operator !=(Decimal a, Decimal b)
    {
        return a.ToString() != b.ToString();
    }
}