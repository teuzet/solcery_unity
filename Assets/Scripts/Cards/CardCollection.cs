using Cysharp.Threading.Tasks;
using Grimmz.Utils;
using UnityEngine;

namespace Grimmz.Modules.CardCollection
{
    public class CardCollection : Singleton<CardCollection>
    {
        public AsyncReactiveProperty<Collection> Collection => _collection;
        private AsyncReactiveProperty<Collection> _collection = new AsyncReactiveProperty<Collection>(null);

        public void UpdateCollection(Collection collection)
        {
            _collection.Value = collection;
        }

        public void Init()
        {
            // Debug.Log("CardCollection Init");
        }

        public void DeInit()
        {
            // Debug.Log("CardCollection DeInit");
        }
    }
}
