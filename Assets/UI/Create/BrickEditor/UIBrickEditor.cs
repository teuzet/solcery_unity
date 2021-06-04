using Grimmz.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace Grimmz.UI.Create.BrickEditor
{
    public class UIBrickEditor : Singleton<UIBrickEditor>
    {
        [SerializeField] private UIBrickSubtypePopup subtypePopup = null;
        [SerializeField] private GameObject horPrefab = null;
        [SerializeField] private GameObject vertPrefab = null;
        [SerializeField] private GameObject selectBrickButtonPrefab = null;
        [SerializeField] private RectTransform content;
        [SerializeField] private GameObject brickPrefab = null;

        private Transform _vert;
        private GameObject _selectBrickButton;

        private void Start()
        {
            CreateFirstButton();
        }

        public void OpenSubtypePopup(BrickType brickType, Transform popupAnchor, Transform vert, GameObject button)
        {
            _vert = vert;
            _selectBrickButton = button;

            subtypePopup.gameObject.SetActive(true);
            subtypePopup.Open(BrickType.Action, popupAnchor, OnBrickAdded);
        }

        public void CloseSubtypePopup()
        {
            subtypePopup.Close();
        }

        private void OnBrickAdded(SubtypeNameConfig subtypeNameConfig)
        {
            Debug.Log($"{subtypeNameConfig.Name} selected");
            CloseSubtypePopup();
            DestroyImmediate(_selectBrickButton);
            CreateBrick(subtypeNameConfig.Config);
        }

        private void CreateBrick(BrickConfig config)
        {
            var brick = Instantiate(brickPrefab, _vert).GetComponent<UIBrick>();
            brick.Init(config);

            var hor = Instantiate(horPrefab, _vert);

            foreach (var slot in config.Slots)
            {
                var vert = Instantiate(vertPrefab, hor.transform);
                var selectBrickButton = Instantiate(selectBrickButtonPrefab, vert.transform).GetComponent<UISelectBrickButton>();
                selectBrickButton.Init(slot.Type, vert.transform);
            }

            LayoutRebuilder.ForceRebuildLayoutImmediate(content);
        }

        private void CreateFirstButton()
        {
            var selectBrickButton = Instantiate(selectBrickButtonPrefab, content).GetComponent<UISelectBrickButton>();
            selectBrickButton.Init(BrickType.Action, content);
        }
    }
}

