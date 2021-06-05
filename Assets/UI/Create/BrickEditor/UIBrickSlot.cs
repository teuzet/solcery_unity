using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Grimmz.UI.Create.BrickEditor
{
    public class UIBrickSlot : MonoBehaviour
    {
        public RectTransform LinePointTop => linePointTop;
        public RectTransform LinePointBot => linePointBot;

        [SerializeField] private Toggle toggle = null;
        [SerializeField] private TextMeshProUGUI slotName = null;

        [SerializeField] private RectTransform linePointTop = null;
        [SerializeField] private RectTransform linePointBot = null;

        public void Init(string name)
        {
            slotName.text = name;
        }
    }
}
