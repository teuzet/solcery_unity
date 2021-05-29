using System.Collections.Generic;

namespace Grimmz
{
    public class BrickConditionAnd : BrickCondition
    {
        private List<BrickCondition> Conditions;

        public override bool Return
        {
            get
            {
                for (int i = 0; i < Conditions.Count; i++)
                {
                    if (!Conditions[i].Return)
                        return false;
                }

                return true;
            }
        }
    }
}
