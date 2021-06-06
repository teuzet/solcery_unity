using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using Grimmz.Utils;

namespace Grimmz.WebGL
{
    public class UnityToReact : Singleton<UnityToReact>
    {
        [DllImport("__Internal")] private static extern void LogToConsole(string message);
        [DllImport("__Internal")] private static extern void OnUnityLoaded();
        [DllImport("__Internal")] private static extern void CreateCard(string card);
        [DllImport("__Internal")] private static extern void CreateFight();
        [DllImport("__Internal")] private static extern void UseCard(string cardMintAccount);


        public void CallLogToConsole(string message)
        {
#if (UNITY_WEBGL && !UNITY_EDITOR)
    LogToConsole (message);
#endif
        }

        public void CallOnUnityLoaded()
        {
#if (UNITY_WEBGL && !UNITY_EDITOR)
    OnUnityLoaded (message);
#endif
        }

        public void CallCreateFight()
        {
#if (UNITY_WEBGL && !UNITY_EDITOR)
    CreateFight();
#endif
        }

        public void CallUseCard(string cardMintAccount)
        {
#if (UNITY_WEBGL && !UNITY_EDITOR)
    UseCard(cardMintAccount);
#endif
        }

        public void CallCreateCard(byte[] card)
        {
#if (UNITY_WEBGL && !UNITY_EDITOR)
        CreateCard(buf);
#endif
        }
    }
}
