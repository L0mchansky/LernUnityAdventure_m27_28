using System.Collections.Generic;

namespace m27_28_task_1
{
    public class Wallet
    {
        private Dictionary<CurrencyType, Currency> _currencies = new();

        private bool TryGetCurrency(CurrencyType type, out Currency currency)
        {
            return _currencies.TryGetValue(type, out currency);
        }

        public void AddValue(CurrencyType type, int value)
        {
            if (value <= 0) return;
            if (TryGetCurrency(type, out Currency currency) == false) return;

            SetValue(type, currency.Value + value);
        }

        public void Spend(CurrencyType type, int value)
        {
            if (TryGetNewValueAfterSpend(type, value, out int newValue) == false) return;

            SetValue(type, newValue);
        }

        public bool CanSpend(CurrencyType type, int value)
        {
            return TryGetNewValueAfterSpend(type, value, out _);
        }

        public int GetValue(CurrencyType type)
        {
            if (TryGetCurrency(type, out Currency currency))
            {
                return currency.Value;
            }

            return 0;
        }

        public Currency AddCurrency(CurrencyType type, int value)
        {
            Currency currency = null;

            if (TryGetCurrency(type, out currency))
            {
                return currency;
            }

            currency = new(type, value);
            _currencies.Add(type, currency);

            return currency;
        }

        private void SetValue(CurrencyType type, int value)
        {
            if (TryGetCurrency(type, out Currency currency))
            {
                currency.SetValue(value);
            }
        }

        private bool TryGetNewValueAfterSpend(CurrencyType type, int value, out int newValue)
        {
            newValue = 0;

            if (value <= 0) return false;
            if (TryGetCurrency(type, out Currency currency) == false) return false;

            newValue = currency.Value - value;

            return newValue >= 0;
        }
    }
}