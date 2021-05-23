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
        }
    }

    public struct WalletConnectionData
    {
        public bool isConnected;
        public int someInt;
    }
}
