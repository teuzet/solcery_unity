using Grimmz.Utils;
using UnityEngine;

namespace Grimmz.Modules.CardCollection
{
    public class CardCollection : Singleton<CardCollection>
    {
        private Collection _collection = null;

        public void UpdateCollection(Collection collection)
        {
            _collection = collection;
        }

        public void Init()
        {
            Debug.Log("CardCollection Init");
        }

        public void DeInit()
        {
            Debug.Log("CardCollection DeInit");
        }
    }
}
