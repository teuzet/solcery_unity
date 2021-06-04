using System;
using System.Collections.Generic;

namespace Grimmz
{
    [Serializable]
    public class BrickData
    {
        public int Type = -1;
        public int Subtype = -1;

        public bool HasField = false;
        public int IntField = -1;
        public string StringField = null;

        public bool HasObjectSelection = false;
        public int Object;

        public BrickData[] Slots;


        public BrickData(BrickConfig config)
        {
            Type = (int)config.Type;
            ///

            UnityEngine.Debug.Log($"Setting Slots to {config.Slots.Count}");
            Slots = new BrickData[config.Slots.Count];
            UnityEngine.Debug.Log(Slots.Length);
        }
    }
}
