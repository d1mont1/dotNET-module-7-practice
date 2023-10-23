using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLibrary
{
    public class CurrencyConverter
    {
        private Dictionary<string, decimal> exchangeRates;

        public CurrencyConverter()
        {
            exchangeRates = new Dictionary<string, decimal>();
        }

        public void AddExchangeRate(string currency, decimal rate)
        {
            exchangeRates[currency] = rate;
        }

        public Money Convert(Money money, string targetCurrency)
        {
            if (!exchangeRates.ContainsKey(money.Currency) || !exchangeRates.ContainsKey(targetCurrency))
            {
                throw new InvalidOperationException("Currency conversion not supported.");
            }

            decimal rate = exchangeRates[targetCurrency] / exchangeRates[money.Currency];
            decimal convertedAmount = money.Amount * rate;

            return new Money(convertedAmount, targetCurrency);
        }
    }
}
