using Grimmz.Utils;
using UnityEngine;

namespace Grimmz.UI.Create.BrickEditor
{
    public class UIBrickEditor : Singleton<UIBrickEditor>
    {
        [SerializeField] private UIBrickSubtypePopup subtypePopup = null;

        public UIBrickSubtypePopup SubtypePopup => subtypePopup;

        public void OpenSubtypePopup(BrickType brickType, Transform anchor)
        {
            subtypePopup.gameObject.SetActive(true);
            subtypePopup.Open(BrickType.Action, anchor);
        }
    }
}

