using UnityEngine;

namespace m27_28_task_1
{
    public class Game: MonoBehaviour
    {
        [SerializeField] private Vector3 _position;
        [SerializeField] private Vector3 _offsetStep;

        [SerializeField] private GameObject _canvas;
        [SerializeField] private GameObject _panel;
        [SerializeField] private WalletUIInitializer _panelPrefabCoin;
        [SerializeField] private WalletUIInitializer _panelPrefabDiamond;
        [SerializeField] private WalletUIInitializer _panelPrefabEnergy;

        private IWalletService _wallet;
        private int _defaultValue = 0;

        private void Awake()
        {
            _wallet = new Wallet();

            CreateCurrency(new Currency(CurrencyType.Coin, _defaultValue), _panelPrefabCoin);
            CreateCurrency(new Currency(CurrencyType.Diamond, _defaultValue), _panelPrefabDiamond);
            CreateCurrency(new Currency(CurrencyType.Energy, _defaultValue), _panelPrefabEnergy);

            if (_canvas != null) _canvas.gameObject.SetActive(true);
        }

        private void CreateCurrency(Currency currency, WalletUIInitializer viewPrefab)
        {
            _wallet.AddCurrency(currency);

            if (viewPrefab != null)
            {
                WalletUIInitializer walletUIInitializer = Instantiate(viewPrefab, _panel.transform);

                RectTransform rectTransform = walletUIInitializer.GetComponent<RectTransform>();

                rectTransform.anchoredPosition = viewPrefab.GetComponent<RectTransform>().anchoredPosition;
                rectTransform.sizeDelta = viewPrefab.GetComponent<RectTransform>().sizeDelta;

                rectTransform.anchoredPosition.Set(_position.x, _position.y);
                _position += _offsetStep;

                walletUIInitializer.Initialize(_wallet, currency);
            }
        }
    }
}