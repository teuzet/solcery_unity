using System.Collections.Generic;

namespace Grimmz
{
    public class BrickConditionOr : BrickCondition
    {
        private List<BrickCondition> Conditions;

        public override bool Return
        {
            get
            {
                for (int i = 0; i < Conditions.Count; i++)
                {
                    if (Conditions[i].Return)
                        return true;
                }

                return false;
            }
        }
    }
}
