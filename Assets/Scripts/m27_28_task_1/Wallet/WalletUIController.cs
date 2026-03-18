using UnityEngine;

namespace m27_28_task_1
{
    public class WalletUIController: MonoBehaviour
    {
        private IWalletService _wallet;
        public void Initialize(IWalletService wallet)
        {
            _wallet = wallet;
        }

        public void AddCoins(int value) => _wallet.Add(CurrencyType.Coin, value);
        public void AddDiamond(int value) => _wallet.Add(CurrencyType.Diamond, value);
        public void AddEnergy(int value) => _wallet.Add(CurrencyType.Energy, value);

        public void SubtractCoins(int value) => _wallet.Subtract(CurrencyType.Coin, value);
        public void SubtractDiamond(int value) => _wallet.Subtract(CurrencyType.Diamond, value);
        public void SubtractEnergy(int value) => _wallet.Subtract(CurrencyType.Energy, value);
    }
}