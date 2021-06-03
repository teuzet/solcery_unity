using Grimmz.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Grimmz.UI.Sandbox
{
    public class UISandbox : Singleton<UISandbox>
    {
        [SerializeField] private TextMeshProUGUI fightLog = null;
        [SerializeField] private Button createFightButton = null;

        void OnEnable()
        {
            createFightButton.onClick.AddListener(() =>
            {
                fightLog.text = "Clicked";
            });
        }

        public void SetText(string newText)
        {
            if (fightLog != null)
                fightLog.text = newText;
        }
    }
}

