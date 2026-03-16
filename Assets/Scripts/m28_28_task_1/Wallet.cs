using System;
using System.Collections.Generic;

namespace m28_28_task_1
{
    public class Wallet: IChangeBalance
    {
        public event Action<string, int> ChangeBalance;

        private Dictionary<string, int> _currencyDictionaries;
        private int _defaultValue = 0;

        public Wallet(Dictionary<string, int> currencyDictionaries = null)
        {
            if (currencyDictionaries != null) {
                _currencyDictionaries = currencyDictionaries;
            }
        }

        public void AddBalance(string currencyName, int value)
        {
            if (value == 0 || value < 0) return;
            if (CheckCurrency(currencyName) == false) return;

            int currentValue = GetBalance(currencyName);
            SetBalance(currencyName, currentValue + value);
        }

        public void SubtractBalance(string currencyName, int value)
        {
            if (value == 0) return;
            if (CheckCurrency(currencyName) == false) return;

            value = Math.Abs(value);
            int currentValue = GetBalance(currencyName);
            SetBalance(currencyName, currentValue - value);
        }

        public int GetBalance(string currencyName)
        {
            if (CheckCurrency(currencyName))
            {
                return _currencyDictionaries[currencyName];
            }

            return 0;
        }

        public void CreateCurrency(string currencyName)
        {
            if (CheckCurrency(currencyName) == false)
            {
                _currencyDictionaries[currencyName] = _defaultValue;
            }
        }

        public Dictionary<string, int> GetCurrencyDictionaries()
        {
            if (_currencyDictionaries.Count != 0)
            {
                return _currencyDictionaries;
            }

            return null;
        }

        private bool CheckCurrency(string currencyName)
        {
            if (_currencyDictionaries.ContainsKey(currencyName))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void SetBalance(string currencyName, int value)
        {
           _currencyDictionaries[currencyName] = value;
           ChangeBalance?.Invoke(currencyName, value);
        }
    }
}
