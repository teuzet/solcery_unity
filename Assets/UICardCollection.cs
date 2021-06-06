using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Linq;
using Grimmz.Modules.CardCollection;
using Grimmz.WebGL;
using UnityEngine;

namespace Grimmz.UI
{
    public class UICardCollection : MonoBehaviour
    {
        [SerializeField] private Transform content;
        [SerializeField] private GameObject cardPrefab;

        private List<UICard> _cards;

        public void Init()
        {
            Debug.Log("UICardCollection Init");

            CardCollection.Instance?.Collection.ForEachAsync(c =>
            {
                UpdateCollection(c);
            }, this.GetCancellationTokenOnDestroy()).Forget();
        }

        public void DeInit()
        {
            Debug.Log("UICardCollection DeInit");
        }

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
            UnityToReact.Instance?.CallUseCard(cardMintAddress);
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
