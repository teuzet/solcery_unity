using Grimmz.Utils;
using UnityEngine;

namespace Grimmz.UI.Create.BrickEditor
{
    public class UIBrickEditor : Singleton<UIBrickEditor>
    {
        [SerializeField] private UIBrickSubtypePopup subtypePopup = null;
        [SerializeField] private Transform content;
        [SerializeField] private GameObject brickPrefab = null;

        public void OpenSubtypePopup(BrickType brickType, Transform anchor)
        {
            subtypePopup.gameObject.SetActive(true);
            subtypePopup.Open(BrickType.Action, anchor, OnBrickAdded);
        }

        public void CloseSubtypePopup()
        {
            subtypePopup.Close();
        }

        private void OnBrickAdded(SubtypeNameConfig subtypeNameConfig, Transform anchor)
        {
            Debug.Log($"{subtypeNameConfig.Name} selected");
            CloseSubtypePopup();
            CreateBrick(subtypeNameConfig.Config, anchor);
        }

        private void CreateBrick(BrickConfig config, Transform anchor)
        {
            var brick = Instantiate(brickPrefab, content).GetComponent<UIBrick>();
            brick.transform.position = anchor.transform.position;
        }
    }
}

