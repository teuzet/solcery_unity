using System.Collections.Generic;
using UnityEngine;

namespace Grimmz.UI.Create.BrickEditor
{
    public class UIBrickSlots : MonoBehaviour
    {
        [SerializeField] private GameObject brickSlotPrefab = null;

        public void Init(List<UIBrickSlotStruct> slotStructs)
        {
            foreach (var slotStruct in slotStructs)
            {
                var slot = Instantiate(brickSlotPrefab, this.transform).GetComponent<UIBrickSlot>();
                slot.Init(slotStruct.Name);
            }
        }
    }
}
