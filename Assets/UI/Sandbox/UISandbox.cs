using Grimmz.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Grimmz.UI.Sandbox
{
    public class UISandbox : Singleton<UISandbox>
    {
        public UICardCollection CardCollection => cardCollection;

        [SerializeField] private TextMeshProUGUI fightLog = null;
        [SerializeField] private Button createFightButton = null;
        [SerializeField] private UICardCollection cardCollection = null;

        public void Init()
        {
            Debug.Log("UISandbox Init");
            cardCollection.Init();

            createFightButton.onClick.AddListener(() =>
           {
               fightLog.text = "Clicked";
           });
        }

        public void DeInit()
        {
            Debug.Log("UISandbox DeInit");
            cardCollection.DeInit();
            createFightButton.onClick.RemoveAllListeners();
        }

        public void SetText(string newText)
        {
            if (fightLog != null)
                fightLog.text = newText;
        }
    }
}

