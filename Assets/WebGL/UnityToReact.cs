using System.Runtime.InteropServices;
using Grimmz.Utils;

namespace Grimmz.WebGL
{
    public class UnityToReact : Singleton<UnityToReact>
    {
        [DllImport("__Internal")] private static extern void LogToConsole(string message);
        [DllImport("__Internal")] private static extern void CreateCard(string card);

        public void CallLogToConsole(string message)
        {
#if (UNITY_WEBGL && !UNITY_EDITOR)
    LogToConsole (message);
#endif
        }

        public void CallCreateCard(string card)
        {
            UnityEngine.Debug.Log("CallCreateCard");
#if (UNITY_WEBGL && !UNITY_EDITOR)
    CreateCard(card);
#endif
        }
    }
}
