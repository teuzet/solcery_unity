using UnityEngine;
using UnityEngine.UI;

namespace Grimmz.UI.Create.BrickEditor
{
    public class UISelectFirstBrickButton : MonoBehaviour
    {
        [SerializeField] private Button button = null;
        [SerializeField] private Transform anchor = null;

        void Start()
        {
            button.onClick.AddListener(() =>
            {
                UIBrickEditor.Instance.OpenSubtypePopup(BrickType.Action, anchor);
                // Destroy(this.gameObject);
            });
        }
    }
}
