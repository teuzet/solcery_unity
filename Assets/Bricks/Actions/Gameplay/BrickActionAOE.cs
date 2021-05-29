using System.Collections.Generic;
using UnityEngine;

namespace Grimmz
{
    public class BrickActionAOE : BrickAction
    {
        private List<Unit> Units;
        private BrickConditionUnit Condition;
        private BrickActionUnit Action;

        public override void Do()
        {
            Debug.Log("Applies action to all units, passing condition");

            for (int i = 0; i < Units.Count; i++)
            {
                Condition.Unit = Units[i];

                if (Condition.Return)
                {
                    Action.Unit = Units[i];
                    Action.Do();
                }
            }
        }
    }
}
