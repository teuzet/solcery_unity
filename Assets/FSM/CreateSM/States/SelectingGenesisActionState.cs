using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Grimmz.FSM.Create
{
    [CreateAssetMenu(menuName = "Grimmz/FSM/Create/States/SelectingGenesisAction", fileName = "SelectingGenesisAction")]
    public class SelectingGenesisActionState : CreateState
    {
        public override async UniTask Enter()
        {
            await base.Enter();
        }

        public override async UniTask Exit()
        {
            await base.Exit();
        }
    }
}
