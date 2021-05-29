namespace Grimmz
{
    public class BrickValueMaxHP : BrickValue
    {
        private Unit Unit;

        public override int Return => Unit.MaxHP;
    }
}
