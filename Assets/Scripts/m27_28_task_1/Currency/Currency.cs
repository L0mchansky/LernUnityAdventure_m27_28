using System;

namespace m27_28_task_1
{
    public class Currency
    {
        public event Action<int> BalanceChanged;

        private CurrencyType _type;
        private int _value;

        public Currency(CurrencyType currencyType, int value)
        {
            _value = value;
            _type = currencyType;
        }
        public int Value => _value;

        public CurrencyType Type => _type;

        public void SetValue(int value)
        {
            _value = value;
            BalanceChanged?.Invoke(value);
        }
    }
}