using UnityEngine;

namespace Grimmz.UI.Sandbox
{
    public class UICardCollection : MonoBehaviour
    {
        [SerializeField] private Transform content;
        [SerializeField] private GameObject cardPrefab;

        public void Des(string jsonCollection)
        {
            var collection = JsonUtility.FromJson<Collection>(jsonCollection);
        }
    }
}
