using UnityEngine;
using TMPro;

namespace Grimmz.UI.Create.BrickEditor
{
    public class UIBrickField : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI fieldName = null;
        [SerializeField] private TMP_InputField fieldInput = null;

        private BrickData _brickData;

        public void Init(string fieldName, UIBrickFieldType fieldType, BrickData data)
        {
            _brickData = data;

            this.fieldName.text = fieldName;

            fieldInput.contentType = fieldType switch
            {
                UIBrickFieldType.Int => TMP_InputField.ContentType.IntegerNumber,
                UIBrickFieldType.String => TMP_InputField.ContentType.Name
            };

            fieldInput.onValueChanged.AddListener((string input) =>
            {
                switch (fieldType)
                {
                    case UIBrickFieldType.Int:
                        if (System.Int32.TryParse(input, out var result))
                            _brickData.IntField = result;
                        break;
                    case UIBrickFieldType.String:
                        _brickData.StringField = input;
                        break;
                };
            });
        }
    }
}
