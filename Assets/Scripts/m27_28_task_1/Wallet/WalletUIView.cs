using m28_28_task_1;
using TMPro;
using UnityEngine;

public class WalletUIView : MonoBehaviour
{
    [SerializeField] TMP_Text currencyUiValue;

    private Currency _currency;
    private IWalletService _wallet;
    
    public void Initialize(IWalletService wallet, Currency currency)
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
        Debug.Log("[OnChangeBalance]: ");
        if (_currency == currency)
        {
            currencyUiValue.text = value.ToString();
        }
    }
}