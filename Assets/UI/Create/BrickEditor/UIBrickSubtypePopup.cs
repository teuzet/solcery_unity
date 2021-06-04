using System;
using System.Collections.Generic;
using UnityEngine;

namespace Grimmz.UI.Create.BrickEditor
{
    public class UIBrickSubtypePopup : MonoBehaviour
    {
        [SerializeField] private GameObject optionPrefab = null;
        [SerializeField] private BrickConfigs brickConfigs = null;

        private Action<SubtypeNameConfig, UISelectBrickButton> _onOptionSelected;
        private List<UIBrickSubtypePopupOption> _options = new List<UIBrickSubtypePopupOption>();

        private UISelectBrickButton _button;

        public void Open(UISelectBrickButton button, Action<SubtypeNameConfig, UISelectBrickButton> onOptionSelected)
        {
            this.transform.SetAsLastSibling();

            _button = button;
            _onOptionSelected = onOptionSelected;

            var subTypeConfigs = brickConfigs.GetConfigSubtypeNamesByType(button.BrickType);

            if (subTypeConfigs != null && subTypeConfigs.Count > 0)
                foreach (var subTypeConfig in subTypeConfigs)
                    AddOption(subTypeConfig);


            this.transform.position = button.transform.position;
        }

        public void Close()
        {
            this.gameObject.SetActive(false);
            ClearAllOptions();
        }

        private void OnOptionSelected(SubtypeNameConfig subtypeNameConfig)
        {
            _onOptionSelected?.Invoke(subtypeNameConfig, _button);
        }

        private void AddOption(SubtypeNameConfig subTypeName)
        {
            var newOption = Instantiate(optionPrefab, this.transform).GetComponent<UIBrickSubtypePopupOption>();
            _options.Add(newOption);
            newOption?.Init(subTypeName, OnOptionSelected);
        }

        private void ClearAllOptions()
        {
            for (int i = _options.Count - 1; i >= 0; i--)
            {
                DestroyImmediate(_options[i].gameObject);
            }

            _options = new List<UIBrickSubtypePopupOption>();
        }
    }
}
