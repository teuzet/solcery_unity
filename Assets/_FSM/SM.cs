using Cysharp.Threading.Tasks;
using Grimmz.Utils;
using UnityEngine;

namespace Grimmz.FSM
{
    public class SM<TSM, TState, TTransition> : UpdateableSingleton<TSM>
    where TSM : SM<TSM, TState, TTransition>
    where TState : State
    where TTransition : Transition<TState>
    {
        private TState _currentState;

        public async UniTask<bool> PerformTransition(TTransition transition)
        {
            if (_currentState != null)
            {
                if (transition.From != null)
                {
                    if (_currentState != transition.From)
                    {
                        Debug.LogError("Current state is different from transition.From!");
                        return false;
                    }
                }
                else
                    await _currentState.Exit();
            }

            await transition.PerformTransition();

            if (transition.To == null)
            {
                Debug.LogError("Transition.To is null!");
                return false;
            }
            else
            {
                _currentState = transition.To;
                await transition.To.Enter();
            }

            return true;
        }

        public override void PerformUpdate()
        {
            _currentState?.PerformUpdate();
        }
    }
}
