using Grimmz.UI.Create.BrickEditor;
using Grimmz.Utils;
using Grimmz.WebGL;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

namespace Grimmz.UI.Create
{
    public class UICreate : Singleton<UICreate>
    {
        [SerializeField] private Button createButton = null;

        public void Init()
        {
            createButton.onClick.AddListener(() =>
            {
                List<byte> buffer = new List<byte>();
                UIBrickEditor.Instance.BrickTree.SerializeToBytes(ref buffer);
                UnityToReact.Instance?.CallCreateCard(buffer.ToArray());
            });
        }

        public void DeInit()
        {
            createButton.onClick.RemoveAllListeners();
        }
    }
}
