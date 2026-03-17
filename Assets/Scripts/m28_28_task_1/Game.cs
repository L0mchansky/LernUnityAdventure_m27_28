using UnityEngine;

namespace m28_28_task_1
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

        private const string CurrencyNameCoin    = "Coin";
        private const string CurrencyNameDiamond = "Diamond";
        private const string CurrencyNameEnergy  = "Energy";

        private IWalletService _wallet;
        private int _defaultValue = 0;

        private void Start()
        {
            _wallet = new Wallet();

            CreateCurrency(new Currency(CurrencyNameCoin, _defaultValue, CurrencyType.Coin), _panelPrefabCoin);
            CreateCurrency(new Currency(CurrencyNameDiamond, _defaultValue, CurrencyType.Diamond), _panelPrefabDiamond);
            CreateCurrency(new Currency(CurrencyNameEnergy, _defaultValue, CurrencyType.Energy), _panelPrefabEnergy);

            _canvas.gameObject.SetActive(true);
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