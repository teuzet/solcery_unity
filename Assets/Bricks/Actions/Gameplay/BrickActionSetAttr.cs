using UnityEngine;

namespace Grimmz
{
    public class BrickActionSetAttr : BrickActionUnit
    {
        private BrickValue Value;
        private string attrName;

        public override void Do()
        {
            Debug.Log("Sets unit attribute named name into value");

            Unit.SetAttr(attrName, Value.Return);
        }
    }
}

