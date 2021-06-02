using TMPro;
using UnityEngine;

namespace Grimmz.UI.Create.BrickEditor
{
    public class UIBrickSubtypePopupOption : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI optionName = null;

        public void SetName(string name)
        {
            if (optionName != null)
                optionName.text = name;
        }
    }
}
