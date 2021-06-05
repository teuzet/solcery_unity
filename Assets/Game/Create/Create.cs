using Grimmz.Utils;
using UnityEngine;

namespace Grimmz
{
    public class Create : Singleton<Create>
    {
        public void Init()
        {
            Debug.Log("Create Init");

        }

        public void DeInit()
        {
            Debug.Log("Create DeInit");
        }
    }
}
