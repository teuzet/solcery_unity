using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Grimmz.UI.Create.BrickEditor
{
    public class UIBrickSubtypePopupOption : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI optionName = null;
        [SerializeField] private Button button = null;

        public void SetName(string name)
        {
            if (optionName != null)
                optionName.text = name;
        }
    }
}
