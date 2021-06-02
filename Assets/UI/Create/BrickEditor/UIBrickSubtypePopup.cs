using UnityEngine;

namespace Grimmz.UI.Create.BrickEditor
{
    public class UIBrickSubtypePopup : MonoBehaviour
    {
        [SerializeField] private GameObject optionPrefab = null;
        [SerializeField] private BrickConfigs brickConfigs = null;

        public void Open(BrickType brickType)
        {
            var names = brickConfigs.GetConfigSubtypeNamesByType(brickType);

            if (names != null && names.Count > 0)
                foreach (var name in names)
                    AddOption(name);

        }

        private void AddOption(string optionName)
        {
            var newOption = Instantiate(optionPrefab, this.transform).GetComponent<UIBrickSubtypePopupOption>();
            newOption?.SetName(optionName);
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                Open(BrickType.Action);
        }
    }
}
