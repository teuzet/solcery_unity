using Grimmz.UI.Wallet;
using Grimmz.Utils;
using UnityEngine;

namespace Grimmz.Modules.Wallet
{
    public class Wallet : Singleton<Wallet>
    {
        public WalletData Data => _data;

        private WalletData _data = null;

        public void Init()
        {
            // Debug.Log("Wallet Init");

            _data = new WalletData();
            UIWallet.Instance?.Init(_data);
        }

        public void DeInit()
        {
            // Debug.Log("Wallet DeInit");
        }
    }
}
