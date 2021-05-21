using Grimmz.Utils;
using Grimmz.WebGL;
using UnityEngine;
using UnityEngine.UI;

namespace Grimmz.UI.Main
{
    public class UIMain : Singleton<UIMain>
    {
        [SerializeField] private Button logButton;

        void Start()
        {
            logButton.onClick.AddListener(() => { UnityToReact.Instance.CallLogToConsole("logging smth to console from Unity"); });
        }
    }
}
