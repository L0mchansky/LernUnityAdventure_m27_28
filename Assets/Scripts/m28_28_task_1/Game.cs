using System.Collections.Generic;
using UnityEngine;

namespace m28_28_task_1
{
    public class Game: MonoBehaviour
    {
        [SerializeField] private Dictionary<string, int> _currencyDictionaries;
        [SerializeField] private WalletView _walletViewPrefab;

        private void Awake()
        {
            Wallet wallet = new Wallet(_currencyDictionaries);

            WalletView walletView = Instantiate(_walletViewPrefab);
            walletView.Initialize(wallet);
        }
    }
}
