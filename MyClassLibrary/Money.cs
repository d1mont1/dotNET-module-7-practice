using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLibrary
{
    public class Money
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; }

        public Money(decimal amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }

        public static Money operator +(Money money1, Money money2)
        {
            if (money1.Currency != money2.Currency)
            {
                throw new InvalidOperationException("Cannot add money in different currencies.");
            }

            return new Money(money1.Amount + money2.Amount, money1.Currency);
        }

        public static Money operator +(Money money, decimal amount)
        {
            return new Money(money.Amount + amount, money.Currency);
        }

        public static bool operator ==(Money money1, Money money2)
        {
            if (ReferenceEquals(money1, money2))
            {
                return true;
            }
            if ((money1 is null) || (money2 is null))
            {
                return false;
            }
            return money1.Amount == money2.Amount && money1.Currency == money2.Currency;
        }

        public static bool operator !=(Money money1, Money money2)
        {
            return !(money1 == money2);
        }

        public override bool Equals(object obj)
        {
            if (obj is Money other)
            {
                return this == other;
            }
            return false;
        }
    }
}
