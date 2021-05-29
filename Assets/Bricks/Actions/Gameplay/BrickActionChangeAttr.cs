using UnityEngine;

namespace Grimmz
{
    public class BrickActionChangeAttr : BrickActionUnit
    {
        private BrickValue Value;
        private string attrName;

        public override void Do()
        {
            Debug.Log("Changes unit attribute named name by value");

            Unit.ChangeAttr(attrName, Value.Return);
        }
    }
}

