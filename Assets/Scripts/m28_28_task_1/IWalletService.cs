using System;

namespace m28_28_task_1
{
    public interface IWalletService
    {
        public event Action<Currency, int> ChangeBalance;

        void Add(CurrencyType type, int value);
        void Subtract(CurrencyType type, int value);
        int Get(CurrencyType type);
        void AddCurrency(Currency currency);
    }
}
