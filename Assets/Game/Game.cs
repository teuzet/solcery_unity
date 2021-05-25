using Cysharp.Threading.Tasks;
using Grimmz.FSM.Game;
using Grimmz.Utils;
using Grimmz.Modules.Wallet;

namespace Grimmz
{
    public class Game : Singleton<Game>
    {
        public void Init()
        {
            UnityEngine.Debug.Log("Game Init");

            Wallet.Instance?.Init();
            GameSM.Instance.PerformInitialTransition().Forget();
        }
    }
}
