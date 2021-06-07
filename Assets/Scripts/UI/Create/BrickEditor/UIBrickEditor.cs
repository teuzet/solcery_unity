using UnityEngine;
using UnityEngine.UI;

namespace Grimmz.UI.Create.BrickEditor
{
    public class UIBrickEditor : MonoBehaviour
    {
        public BrickTree BrickTree => _brickTree;

        [SerializeField] private UIBrickSubtypePopup subtypePopup = null;
        [SerializeField] private GameObject horPrefab = null;
        [SerializeField] private GameObject vertPrefab = null;
        [SerializeField] private GameObject selectBrickButtonPrefab = null;
        [SerializeField] private RectTransform content;
        [SerializeField] private GameObject brickPrefab = null;

        private BrickTree _brickTree;

        private void Start()
        {
            _brickTree = new BrickTree();
            CreateFirstButton();
        }

        public void OpenSubtypePopup(UISelectBrickButton button)
        {
            subtypePopup.gameObject.SetActive(true);
            subtypePopup.Open(button, OnBrickAdded);
        }

        public void CloseSubtypePopup()
        {
            subtypePopup.Close();
        }

        private void OnBrickAdded(SubtypeNameConfig subtypeNameConfig, UISelectBrickButton button)
        {
            // Debug.Log($"{subtypeNameConfig.Name} selected");
            CloseSubtypePopup();
            DestroyImmediate(button.gameObject);
            CreateBrick(subtypeNameConfig.Config, button);
        }

        private void CreateBrick(BrickConfig config, UISelectBrickButton button)
        {
            var brickData = new BrickData(config);

            var brick = Instantiate(brickPrefab, button.Vert).GetComponent<UIBrick>();
            brick.Init(config, brickData);

            if (button.Parent == null)
            {
                // Debug.Log("Setting Genesis BrickData");
                _brickTree.SetGenesis(brickData);
            }
            else
            {
                button.Parent.Data.Slots[button.IndexInParentSlots] = brickData;
                button.Parent.Slots.Slots[button.IndexInParentSlots].SetFilled(true);
            }

            var hor = Instantiate(horPrefab, button.Vert);

            for (int i = 0; i < config.Slots.Count; i++)
            {
                var vert = Instantiate(vertPrefab, hor.transform);
                var selectBrickButton = Instantiate(selectBrickButtonPrefab, vert.transform).GetComponent<UISelectBrickButton>();
                selectBrickButton.Init(config.Slots[i].Type, vert.transform, brick, i);
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

