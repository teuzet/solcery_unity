using Grimmz.UI.Create.BrickEditor;
using Grimmz.Utils;
using Grimmz.WebGL;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace Grimmz.UI.Create
{
    public class UICreate : Singleton<UICreate>
    {
        [SerializeField] private UICreateCard createCard = null;
        [SerializeField] private Button createButton = null;

        public void Init()
        {
            createCard.Init();

            createButton.onClick.AddListener(() =>
            {
                UIBrickEditor.Instance.BrickTree.MetaData.Name = string.IsNullOrEmpty(createCard.CardNameInput.text) ? "Card" : createCard.CardNameInput.text;
                UIBrickEditor.Instance.BrickTree.MetaData.Description = string.IsNullOrEmpty(createCard.CardDescriptionInput.text) ? "Description" : createCard.CardDescriptionInput.text;
                UIBrickEditor.Instance.BrickTree.MetaData.Picture = createCard.CurrentPictureIndex;

                List<byte> buffer = new List<byte>();
                UIBrickEditor.Instance.BrickTree.SerializeToBytes(ref buffer);
                UnityToReact.Instance?.CallCreateCard(buffer.ToArray());
            });
        }

        public void DeInit()
        {
            createCard.DeInit();
            createButton.onClick.RemoveAllListeners();
        }
    }
}
