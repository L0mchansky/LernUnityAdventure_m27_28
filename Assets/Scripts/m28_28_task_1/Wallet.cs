using System;
using System.Collections.Generic;

namespace m28_28_task_1
{
    public class Wallet: IWalletService
    {
        public event Action<Currency, int> ChangeBalance;

        private List<Currency> _currencies = new();

        public void Add(CurrencyType type, int value)
        {
            if (value == 0 || value < 0) return;
            if (CheckCurrency(type) == false) return;

            int currentValue = Get(type);
            Set(type, currentValue + value);
        }

        public void Subtract(CurrencyType type, int value)
        {
            if (value == 0) return;
            if (CheckCurrency(type) == false) return;

            value = Math.Abs(value);
            int currentValue = Get(type);
            Set(type, currentValue - value);
        }

        public int Get(CurrencyType type)
        {
            if (CheckCurrency(type))
            {
                foreach (var currency in _currencies)
                {
                    if (currency.Type == type)
                        return currency.Value;
                }
            }

            return 0;
        }

        public void AddCurrency(Currency currency)
        {
            if (CheckCurrency(currency.Type) == true) return;

            _currencies.Add(currency);
        }

        private bool CheckCurrency(CurrencyType type)
        {
            if (_currencies.Count == 0) return false;

            foreach (var currency in _currencies)
            {
                if (currency.Type == type)
                    return true;
            }

            return false;
        }

        private void Set(CurrencyType type, int value)
        {
            foreach (var currency in _currencies)
            {
                if (currency.Type == type)
                {
                    currency.SetValue(value);
                    ChangeBalance?.Invoke(currency, value);
                    return;
                } 
            }
        }
    }
}