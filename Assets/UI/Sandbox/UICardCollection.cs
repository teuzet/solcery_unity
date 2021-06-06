using System.Collections.Generic;
using UnityEngine;

namespace Grimmz.UI
{
    public class UICardCollection : MonoBehaviour
    {
        [SerializeField] private Transform content;
        [SerializeField] private GameObject cardPrefab;

        private List<UICard> _cards;

        public void UpdateCollection(Collection collection)
        {
            DeleteAllCards();
            _cards = new List<UICard>();

            foreach (var cardData in collection.Cards)
            {
                var newCard = Instantiate(cardPrefab, content).GetComponent<UICard>();
                newCard.Init(cardData, OnCardCasted);

                _cards.Add(newCard);
            }
        }

        private void OnCardCasted(string cardMintAddress)
        {
            Debug.Log("Card casted");
        }

        private void DeleteAllCards()
        {
            for (int i = _cards.Count - 1; i >= 0; i--)
            {
                _cards[i].DeInit();
                DestroyImmediate(_cards[i].gameObject);
            }
        }
    }
}
