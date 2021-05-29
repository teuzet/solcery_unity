namespace Grimmz
{
    public class BrickConditionNot : BrickCondition
    {
        private BrickCondition condition;

        public override bool Return => !condition.Return;
    }
}

