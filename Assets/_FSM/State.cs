using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Grimmz.FSM
{
    public abstract class State : SerializedScriptableObject
    {
#pragma warning disable 1998
        public virtual async UniTask Enter() { Debug.Log($"{name} enter"); }
        public virtual async UniTask Exit() { Debug.Log($"{name} exit"); }
#pragma warning restore 1998

        public virtual void PerformUpdate() { }
    }
}