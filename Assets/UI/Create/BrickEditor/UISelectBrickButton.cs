using UnityEngine;
using UnityEngine.UI;

namespace Grimmz.UI.Create.BrickEditor
{
    public class UISelectBrickButton : MonoBehaviour
    {
        [SerializeField] private Transform verticalGroup = null;
        [SerializeField] private Button button = null;

        private BrickType _brickType;

        public void Init(BrickType brickType, Transform vert)
        {
            _brickType = brickType;
            verticalGroup = vert;
        }

        void Start()
        {
            button.onClick.AddListener(() =>
            {
                UIBrickEditor.Instance.OpenSubtypePopup(BrickType.Action, this.transform, verticalGroup, this.gameObject);
            });
        }
    }
}
