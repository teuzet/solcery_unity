using Grimmz.UI.Create.BrickEditor;
using Grimmz.Utils;
using Grimmz.WebGL;
using UnityEngine;
using UnityEngine.UI;

namespace Grimmz.UI.Create
{
    public class UICreate : Singleton<UICreate>
    {
        [SerializeField] private Button createButton = null;

        public void Init()
        {
            createButton.onClick.AddListener(() =>
            {
                var serializedCard = UIBrickEditor.Instance.BrickTree.Serialize();
                UnityToReact.Instance.CallCreateCard(serializedCard);
            });
        }

        public void DeInit()
        {
            createButton.onClick.RemoveAllListeners();
        }
    }
}
