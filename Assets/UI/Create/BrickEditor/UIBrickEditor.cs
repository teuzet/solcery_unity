using Grimmz.Utils;
using UnityEngine;

namespace Grimmz.UI.Create.BrickEditor
{
    public class UIBrickEditor : Singleton<UIBrickEditor>
    {
        [SerializeField] private UIBrickSubtypePopup subtypePopup;

        public UIBrickSubtypePopup SubtypePopup => subtypePopup;
    }
}

