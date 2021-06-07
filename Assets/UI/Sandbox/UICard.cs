using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Grimmz.UI
{
    public class UICard : MonoBehaviour
    {
        [SerializeField] private Button button = null;
        [SerializeField] private Image cardImage = null;
        [SerializeField] private TextMeshProUGUI cardName = null;
        [SerializeField] private TextMeshProUGUI cardDescription = null;

        public void Init(CardData cardData, Action<string> onCardCasted)
        {
            // cardImage 
            cardName.text = cardData.Metadata.Name;
            cardDescription.text = cardData.Metadata.Description;

            button.onClick.AddListener(() => { onCardCasted?.Invoke(cardData.MintAdress); });
        }

        public void DeInit()
        {
            button.onClick.RemoveAllListeners();
        }
    }
}

