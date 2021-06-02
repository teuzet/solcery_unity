using TMPro;
using UnityEngine;

namespace Grimmz.UI.Create.BrickEditor
{
    public class UIBrick : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI typeName = null;
        [SerializeField] private TextMeshProUGUI subtypeName = null;
        [SerializeField] private TextMeshProUGUI description = null;

        [SerializeField] private UIBrickObjectSwitcher objectSwitcher = null;
        [SerializeField] private UIBrickSlots slots = null;
    }
}
