using Grimmz.Modules.Wallet;
using Grimmz.Utils;
using UnityEngine;

namespace Grimmz.WebGL
{
    public class ReactToUnity : Singleton<ReactToUnity>
    {
        public void SetWalletConnected(string data)
        {
            var w = JsonUtility.FromJson<WalletConnectionData>(data);
            Debug.Log($"Unity knows that wallet is connected: {w.isConnected} - {w.someInt}");
            Wallet.Instance.Data.IsWalletConnected.Value = w.isConnected;
        }
    }

    public struct WalletConnectionData
    {
        public bool isConnected;
        public int someInt;
    }
}
