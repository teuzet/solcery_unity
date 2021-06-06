using Grimmz.Utils;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

namespace Grimmz.UI.Create.BrickEditor
{
    public class UIBrickEditor : Singleton<UIBrickEditor>
    {
        public BrickTree BrickTree => _brickTree;

        [SerializeField] private UIBrickSubtypePopup subtypePopup = null;
        [SerializeField] private GameObject horPrefab = null;
        [SerializeField] private GameObject vertPrefab = null;
        [SerializeField] private GameObject selectBrickButtonPrefab = null;
        [SerializeField] private GameObject lineRendererPrefab = null;
        [SerializeField] private RectTransform knob1 = null;
        [SerializeField] private RectTransform knob2 = null;
        [SerializeField] private RectTransform knob3 = null;
        [SerializeField] private RectTransform knob4 = null;
        [SerializeField] private UILineRenderer lr = null;
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
            Debug.Log($"{subtypeNameConfig.Name} selected");
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
                Debug.Log("Setting Genesis BrickData");
                _brickTree.SetGenesis(brickData);
            }
            else
            {
                Debug.Log($"Parent Slots Count: {button.Parent.Data.Slots.Length}");
                Debug.Log($"Adding Slot {button.IndexInParentSlots} to {button.Parent.Data.Type}");
                button.Parent.Data.Slots[button.IndexInParentSlots] = brickData;

                // var lineRenderer = Instantiate(lineRendererPrefab, content).GetComponent<UILineRenderer>();
                // lineRenderer.Points = new Vector2[] {
                //     lineRenderer.transform.TransformPoint(button.Parent.Slots.Slots[button.IndexInParentSlots].LinePointTop.position),
                //     lineRenderer.transform.TransformPoint(button.Parent.Slots.Slots[button.IndexInParentSlots].LinePointBot.position),
                //     lineRenderer.transform.TransformPoint(brick.LinePointTop.position),
                //     lineRenderer.transform.TransformPoint(brick.LinePointBot.position)
                //     };

                // knob1.transform.position = button.Parent.Slots.Slots[button.IndexInParentSlots].LinePointTop.transform.position;
                // knob1.SetParent(lr.transform);
                // knob2.transform.position = button.Parent.Slots.Slots[button.IndexInParentSlots].LinePointBot.transform.position;
                // knob2.SetParent(lr.transform);
                // knob3.transform.position = brick.LinePointTop.transform.position;
                // knob3.SetParent(lr.transform);
                // knob4.transform.position = brick.LinePointBot.transform.position;
                // knob4.SetParent(lr.transform);
                // lr.Points = new Vector2[] { knob1.localPosition, knob2.localPosition, knob3.localPosition, knob4.localPosition };
            }

            var hor = Instantiate(horPrefab, button.Vert);

            for (int i = 0; i < config.Slots.Count; i++)
            {
                var vert = Instantiate(vertPrefab, hor.transform);
                var selectBrickButton = Instantiate(selectBrickButtonPrefab, vert.transform).GetComponent<UISelectBrickButton>();
                selectBrickButton.Init(config.Slots[i].Type, vert.transform, brick, i);
                Debug.Log(selectBrickButton.Parent.Data.Slots.Length);


                // var lr = Instantiate(lineRendererPrefab, content).GetComponent<UILineRenderer>();
                // lr.transform.position = brick.Slots.Slots[i].LinePointTop.transform.position;

                // var dot1 = new GameObject("Dot1");
                // dot1.transform.position = brick.Slots.Slots[i].LinePointTop.transform.position;
                // dot1.transform.SetParent(lr.transform);

                // var dot2 = new GameObject("Dot2");
                // dot2.transform.position = brick.Slots.Slots[i].LinePointBot.transform.position;
                // dot2.transform.SetParent(lr.transform);

                // var dot3 = new GameObject("Dot3");
                // dot3.transform.position = selectBrickButton.LinePointTop.transform.position;
                // dot3.transform.SetParent(lr.transform);

                // var dot4 = new GameObject("Dot4");
                // dot4.transform.position = selectBrickButton.LinePointBot.transform.position;
                // dot4.transform.SetParent(lr.transform);

                // lr.Points = new Vector2[] { dot1.transform.localPosition, dot2.transform.localPosition, dot3.transform.localPosition, dot4.transform.localPosition };
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

