using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Grimmz.FSM.Game
{
    [CreateAssetMenu(menuName = "Grimmz/FSM/Game/States/Create", fileName = "Create")]
    public class CreateState : GameState
    {
        public override async UniTask Enter()
        {
            await base.Enter();
            Create.Instance?.Init();
        }

        public override async UniTask Exit()
        {
            Create.Instance?.DeInit();
            await base.Exit();
        }
    }
}
