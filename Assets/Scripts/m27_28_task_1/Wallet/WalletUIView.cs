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

            _currency.ChangeBalance += OnChangeBalance;
        }

        private void OnDestroy()
        {
            _currency.ChangeBalance -= OnChangeBalance;
        }

        private void OnChangeBalance(Currency currency, int value)
        {
            if (_currency == currency)
            {
                currencyUiValue.text = value.ToString();
            }
        }
    }
}