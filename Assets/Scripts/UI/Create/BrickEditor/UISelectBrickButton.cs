using UnityEngine;
using UnityEngine.UI;

namespace Grimmz.UI.Create.BrickEditor
{
    public class UISelectBrickButton : MonoBehaviour
    {
        public RectTransform LinePointTop => linePointTop;
        public RectTransform LinePointBot => linePointBot;

        [SerializeField] private RectTransform linePointTop = null;
        [SerializeField] private RectTransform linePointBot = null;
        [SerializeField] private Transform verticalGroup = null;
        [SerializeField] private Button button = null;

        public Transform Vert => verticalGroup;
        public BrickType BrickType { get; private set; }
        public UIBrick Parent { get; private set; }
        public int IndexInParentSlots { get; private set; }

        public void Init(BrickType brickType, Transform vert, UIBrick parent = null, int indexInParentSlots = 0)
        {
            BrickType = brickType;
            verticalGroup = vert;
            Parent = parent;
            IndexInParentSlots = indexInParentSlots;

            button.onClick.AddListener(() =>
            {
                UICreate.Instance.BrickEditor.OpenSubtypePopup(this);
            });
        }

        private void OnDisable()
        {
            button.onClick.RemoveAllListeners();
        }
    }
}
