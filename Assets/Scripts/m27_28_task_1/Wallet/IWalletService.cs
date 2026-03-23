using System;

namespace m27_28_task_1
{
    public interface IWalletService
    {
        void AddValue(CurrencyType type, int value);
        void Spend(CurrencyType type, int value);
        bool CanSpend(CurrencyType type, int value);
        int GetValue(CurrencyType type);
        Currency AddCurrency(CurrencyType type, int value);
    }
}
