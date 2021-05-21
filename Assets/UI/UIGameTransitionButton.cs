using UnityEngine;
using Grimmz.FSM.Game;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;

namespace Grimmz.UI
{
    [RequireComponent(typeof(Button))]
    public class UIGameTransitionButton : MonoBehaviour
    {
        [SerializeField] private GameTransition transition = null;
        [SerializeField] private Button button = null;

        private void OnEnable()
        {
            button.onClick.AddListener(() => { GameSM.Instance.PerformTransition(transition).Forget(); });
        }

        private void OnDisable()
        {
            button.onClick.RemoveAllListeners();
        }
    }
}
