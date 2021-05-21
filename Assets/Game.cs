using Cysharp.Threading.Tasks;
using Grimmz.FSM.Game;
using UnityEngine;

namespace Grimmz
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private GameTransition initialTransition = null;

        void Start()
        {
            GameSM.Instance.PerformTransition(initialTransition).Forget();
        }
    }
}
