using Cysharp.Threading.Tasks;
using Grimmz.FSM.Game;
using Grimmz.Utils;
using Grimmz.Modules.Wallet;
using Grimmz.Modules.CardCollection;

namespace Grimmz
{
    public class Game : Singleton<Game>
    {
        public void Init()
        {
            UnityEngine.Debug.Log("Game Init");

            Wallet.Instance?.Init();
            CardCollection.Instance?.Init();
            GameSM.Instance.PerformInitialTransition().Forget();
        }

        public void DeInit()
        {
            UnityEngine.Debug.Log("Game DeInit");

            Wallet.Instance?.DeInit();
            CardCollection.Instance?.DeInit();
        }
    }
}
