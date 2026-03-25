using UnityEngine;

namespace m27_28_task_1
{
    public class Game: MonoBehaviour
    {
        [SerializeField] private GameObject _canvas;
        [SerializeField] private GameObject _panel;
        [SerializeField] private WalletUIInitializer _panelPrefabCoin;
        [SerializeField] private WalletUIInitializer _panelPrefabDiamond;
        [SerializeField] private WalletUIInitializer _panelPrefabEnergy;

        private Wallet _wallet;
        private int _defaultValue = 0;

        private void Awake()
        {
            _wallet = new Wallet();

            CreateCurrency(CurrencyType.Coin, _defaultValue, _panelPrefabCoin);
            CreateCurrency(CurrencyType.Diamond, _defaultValue, _panelPrefabDiamond);
            CreateCurrency(CurrencyType.Energy, _defaultValue, _panelPrefabEnergy);

            if (_canvas != null) _canvas.gameObject.SetActive(true);
        }

        private void CreateCurrency(CurrencyType type, int value, WalletUIInitializer viewPrefab)
        {
            Currency currency = _wallet.GetOrCreateCurrency(type, value);

            if (viewPrefab != null)
            {
                WalletUIInitializer walletUIInitializer = Instantiate(viewPrefab, _panel.transform);
                walletUIInitializer.Initialize(_wallet, currency);
            }
        }
    }
}