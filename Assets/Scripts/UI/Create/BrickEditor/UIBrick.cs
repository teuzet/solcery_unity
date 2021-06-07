using System;
using TMPro;
using UnityEngine;

namespace Grimmz.UI.Create.BrickEditor
{
    public class UIBrick : MonoBehaviour
    {
        public BrickData Data { get; private set; }
        public RectTransform LinePointTop => linePointTop;
        public RectTransform LinePointBot => linePointBot;
        public UIBrickSlots Slots => slots;

        [SerializeField] private RectTransform linePointTop = null;
        [SerializeField] private RectTransform linePointBot = null;

        [SerializeField] private TextMeshProUGUI typeName = null;
        [SerializeField] private TextMeshProUGUI subtypeName = null;
        [SerializeField] private TextMeshProUGUI description = null;

        [SerializeField] private UIBrickField field = null;

        [SerializeField] private UIBrickObjectSwitcher objectSwitcher = null;
        [SerializeField] private UIBrickSlots slots = null;

        public void Init(BrickConfig config, BrickData data)
        {
            Data = data;

            typeName.text = Enum.GetName(typeof(BrickType), config.Type);
            subtypeName.text = BrickConfigs.GetSubtypeName(config.Type, config.Subtype);
            description.text = config.Description;

            field.gameObject.SetActive(config.HasField);
            if (config.HasField) field.Init(config.FieldName, config.FieldType, data);

            objectSwitcher.gameObject.SetActive(config.HasObjectSelection);
            objectSwitcher.Init(data);
            slots.Init(config.Slots);
        }
    }
}
