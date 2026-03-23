using UnityEngine;

namespace m27_28_task_1
{
    public class WalletUIController: MonoBehaviour
    {
        private Wallet _wallet;
        public void Initialize(Wallet wallet)
        {
            _wallet = wallet;
        }

        public void AddCoins(int value) => _wallet.AddValue(CurrencyType.Coin, value);
        public void AddDiamond(int value) => _wallet.AddValue(CurrencyType.Diamond, value);
        public void AddEnergy(int value) => _wallet.AddValue(CurrencyType.Energy, value);

        public void SubtractCoins(int value)
        {
            if (_wallet.CanSpend(CurrencyType.Coin, value))
                _wallet.Spend(CurrencyType.Coin, value);
        }
        public void SubtractDiamond(int value)
        {
            if (_wallet.CanSpend(CurrencyType.Diamond, value))
                _wallet.Spend(CurrencyType.Diamond, value);
        }
        public void SubtractEnergy(int value)
        {
            if (_wallet.CanSpend(CurrencyType.Energy, value))
                _wallet.Spend(CurrencyType.Energy, value);
        }
    }
}