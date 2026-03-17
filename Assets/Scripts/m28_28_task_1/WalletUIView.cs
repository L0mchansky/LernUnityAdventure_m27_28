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
        _wallet = wallet;
        _currency = currency;

        _wallet.ChangeBalance += OnChangeBalance;
    }

    private void OnDestroy()
    {
        _wallet.ChangeBalance -= OnChangeBalance;
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