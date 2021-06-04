using System;
using TMPro;
using UnityEngine;

namespace Grimmz.UI.Create.BrickEditor
{
    public class UIBrick : MonoBehaviour
    {
        [SerializeField] private BrickConfigs brickConfigs = null;

        [SerializeField] private TextMeshProUGUI typeName = null;
        [SerializeField] private TextMeshProUGUI subtypeName = null;
        [SerializeField] private TextMeshProUGUI description = null;

        [SerializeField] private UIBrickObjectSwitcher objectSwitcher = null;
        [SerializeField] private UIBrickSlots slots = null;

        public BrickData Data { get; private set; }

        public void Init(BrickConfig config, BrickData data)
        {
            Data = data;
            
            typeName.text = Enum.GetName(typeof(BrickType), config.Type);
            subtypeName.text = brickConfigs.GetSubtypeName(config.Type, config.Subtype);
            description.text = config.Description;

            objectSwitcher.gameObject.SetActive(config.HasObjectSelection);
            slots.Init(config.Slots);
        }
    }
}
