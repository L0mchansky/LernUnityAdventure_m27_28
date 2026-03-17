using System;

namespace m28_28_task_1
{
    public interface IWalletService
    {
        void Add(CurrencyType type, int value);
        void Subtract(CurrencyType type, int value);
        int Get(CurrencyType type);
        void AddCurrency(Currency currency);
    }
}
