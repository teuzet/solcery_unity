using Grimmz.Utils;
using Grimmz.WebGL;
using UnityEngine;
using UnityEngine.UI;

namespace Grimmz.UI.Menu
{
    public class UIMenu : Singleton<UIMenu>
    {
        [SerializeField] private Button logButton = null;

        void Start()
        {
            logButton.onClick.AddListener(() => { UnityToReact.Instance.CallLogToConsole("logging smth to console from Unity"); });
        }
    }
}
