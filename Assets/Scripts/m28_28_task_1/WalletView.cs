using m28_28_task_1;
using UnityEngine;

public class WalletView : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    public void Initialize(Wallet wallet)
    {
        _wallet = wallet;
    }
}