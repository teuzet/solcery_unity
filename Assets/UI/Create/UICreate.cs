using Grimmz.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace Grimmz.UI.Create
{
    public class UICreate : Singleton<UICreate>
    {
        [SerializeField] private Button createButton = null;

        //TODO: do it on Init()
        void Start()
        {
            createButton.onClick.AddListener(() =>
            {
                
            });
        }

        //TODO: do it on DeInit()
        void OnDisable()
        {
            createButton.onClick.RemoveAllListeners();
        }
    }
}
