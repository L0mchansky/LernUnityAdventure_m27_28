using UnityEngine;

namespace m28_28_task_1
{
    public class WalletUIInitializer : MonoBehaviour
    {
        [SerializeField] private WalletUIController _controller;
        [SerializeField] private WalletUIView _view;

        private IWalletService _wallet;

        public void Initialize(IWalletService wallet, Currency currency)
        {
            _wallet = wallet;

            _controller.Initialize(_wallet);
            _view.Initialize(_wallet, currency);
        }
    }
}