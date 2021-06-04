using System;
using System.Collections.Generic;
using UnityEngine;

namespace Grimmz.UI.Create.BrickEditor
{
    public class UIBrickSubtypePopup : MonoBehaviour
    {
        [SerializeField] private GameObject optionPrefab = null;
        [SerializeField] private BrickConfigs brickConfigs = null;

        private BrickType _brickType;
        private Transform _anchor;
        private Action<SubtypeNameConfig, Transform> _onOptionSelected;
        private List<UIBrickSubtypePopupOption> _options = new List<UIBrickSubtypePopupOption>();

        public void Open(BrickType brickType, Transform anchor, Action<SubtypeNameConfig, Transform> onOptionSelected)
        {
            _brickType = brickType;
            _anchor = anchor;
            _onOptionSelected = onOptionSelected;

            var subTypeConfigs = brickConfigs.GetConfigSubtypeNamesByType(brickType);

            if (subTypeConfigs != null && subTypeConfigs.Count > 0)
                foreach (var subTypeConfig in subTypeConfigs)
                    AddOption(subTypeConfig);


            this.transform.position = anchor.position;
        }

        public void Close()
        {
            this.gameObject.SetActive(false);
            ClearAllOptions();
        }

        private void OnOptionSelected(SubtypeNameConfig subtypeNameConfig)
        {
            _onOptionSelected?.Invoke(subtypeNameConfig, _anchor);
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
