using UnityEngine;

namespace Grimmz
{
    public class BrickActionConditional : BrickAction
    {
        private BrickCondition Condition;
        private BrickAction PositiveAction;
        private BrickAction NegativeAction;

        public override void Do()
        {
            Debug.Log("Applies positive if condition is passed, otherwise applies negative");

            if (Condition.Return)
                PositiveAction.Do();
            else
                NegativeAction.Do();
        }
    }
}
