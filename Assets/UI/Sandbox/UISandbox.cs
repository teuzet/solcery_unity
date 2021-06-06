using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Linq;
using Grimmz.Modules.FightModule;
using Grimmz.Utils;
using Grimmz.WebGL;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Grimmz.UI.Sandbox
{
    public class UISandbox : Singleton<UISandbox>
    {
        public UICardCollection CardCollection => cardCollection;

        [SerializeField] private Button createFightButton = null;
        [SerializeField] private UICardCollection cardCollection = null;

        [SerializeField] private TextMeshProUGUI hp1Text = null;
        [SerializeField] private TextMeshProUGUI hp2Text = null;

        public void Init()
        {
            Debug.Log("UISandbox Init");
            cardCollection.Init();

            if (FightModule.Instance.Fight.Value == null)
            {
                createFightButton.onClick.AddListener(() =>
                {
                    UnityToReact.Instance?.CallCreateFight();
                    createFightButton.gameObject.SetActive(false);
                });
            }
            else
            {
                createFightButton.gameObject.SetActive(false);
                UpdateFight(FightModule.Instance.Fight.Value);
            }

            // subscribe to fight updates
            FightModule.Instance?.Fight.WithoutCurrent().ForEachAsync(f =>
            {
                if (f != null) UpdateFight(f);
            }, this.GetCancellationTokenOnDestroy()).Forget();
        }

        private void UpdateFight(Fight fight)
        {
            hp1Text.text = fight.HP1.ToString();
            hp2Text.text = fight.HP2.ToString();
        }

        public void DeInit()
        {
            Debug.Log("UISandbox DeInit");
            cardCollection.DeInit();
            createFightButton.onClick.RemoveAllListeners();
        }
    }
}

