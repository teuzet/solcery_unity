using System.Runtime.InteropServices;
using Grimmz.Utils;

namespace Grimmz.WebGL
{
    public class UnityToReact : Singleton<UnityToReact>
    {
        [DllImport("__Internal")]
        private static extern void LogToConsole(string message);

        public void CallLogToConsole(string message)
        {
#if (UNITY_WEBGL && !UNITY_EDITOR)
    LogToConsole (message);
#endif
        }
    }
}
