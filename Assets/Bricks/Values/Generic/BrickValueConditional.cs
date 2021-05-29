namespace Grimmz
{
    public class BrickValueConditional : BrickValue
    {
        private BrickCondition Condition;
        private BrickValue Positive;
        private BrickValue Negative;

        public override int Return => Condition.Return ? Positive.Return : Negative.Return;
    }
}
