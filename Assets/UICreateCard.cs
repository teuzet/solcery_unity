using UnityEngine;
using TMPro;

namespace Grimmz.UI.Create
{
    public class UICreateCard : MonoBehaviour
    {
        public TMP_InputField CardNameInput => cardNameInput;
        public TMP_InputField CardDescriptionInput => cardDescriptionInput;

        [SerializeField] private TMP_InputField cardNameInput;
        [SerializeField] private TMP_InputField cardDescriptionInput;

        public void Init()
        {

        }

        public void DeInit()
        {

        }
    }
}
