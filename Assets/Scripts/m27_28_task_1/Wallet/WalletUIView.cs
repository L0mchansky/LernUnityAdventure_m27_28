using TMPro;
using UnityEngine;

namespace m27_28_task_1 {
    public class WalletUIView : MonoBehaviour
    {
        [SerializeField] TMP_Text currencyUiValue;

        private Currency _currency;

        public void Initialize(Currency currency)
        {
            _currency = currency;

            _currency.BalanceChanged += OnBalanceChanged;
        }

        private void OnDestroy()
        {
            _currency.BalanceChanged -= OnBalanceChanged;
        }

        private void OnBalanceChanged(int value)
        {
            currencyUiValue.text = value.ToString();
        }
    }
}