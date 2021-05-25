using Grimmz.Utils;
using UnityEngine;

namespace Grimmz
{
    public class Sandbox : Singleton<Sandbox>
    {
        public void Init()
        {
            Debug.Log("Sandbox Init");
        }

        public void DeInit()
        {
            Debug.Log("Sandbox DeInit");
        }
    }
}
