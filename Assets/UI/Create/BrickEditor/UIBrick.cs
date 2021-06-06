using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI.Extensions;

namespace Grimmz.UI.Create.BrickEditor
{
    public class UIBrick : MonoBehaviour
    {
        public BrickData Data { get; private set; }
        public RectTransform LinePointTop => linePointTop;
        public RectTransform LinePointBot => linePointBot;
        public UIBrickSlots Slots => slots;

        [SerializeField] private BrickConfigs brickConfigs = null;

        [SerializeField] private RectTransform linePointTop = null;
        [SerializeField] private RectTransform linePointBot = null;

        [SerializeField] private TextMeshProUGUI typeName = null;
        [SerializeField] private TextMeshProUGUI subtypeName = null;
        [SerializeField] private TextMeshProUGUI description = null;

        [SerializeField] private UIBrickObjectSwitcher objectSwitcher = null;
        [SerializeField] private UIBrickSlots slots = null;

        public void Init(BrickConfig config, BrickData data)
        {
            Data = data;

            typeName.text = Enum.GetName(typeof(BrickType), config.Type);
            subtypeName.text = BrickConfigs.GetSubtypeName(config.Type, config.Subtype);
            description.text = config.Description;

            objectSwitcher.gameObject.SetActive(config.HasObjectSelection);
            slots.Init(config.Slots);
        }
    }
}
