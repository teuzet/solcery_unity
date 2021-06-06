using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using Grimmz.Utils;

namespace Grimmz.WebGL
{
    public class UnityToReact : Singleton<UnityToReact>
    {
        [DllImport("__Internal")] private static extern void LogToConsole(string message);
        [DllImport("__Internal")] private static extern void CreateCard(List<byte> card);

        public void CallLogToConsole(string message)
        {
#if (UNITY_WEBGL && !UNITY_EDITOR)
    LogToConsole (message);
#endif
        }

        public void CallCreateCard(byte[] card)
        {

            UnityEngine.Debug.Log("CallCreateCard");
            string buf = "";
            foreach (byte b in card) {
                buf = buf + b + ", ";
            }
            UnityEngine.Debug.Log(buf);

#if (UNITY_WEBGL && !UNITY_EDITOR)
    CreateCard(card);
#endif
        }
    }
}
