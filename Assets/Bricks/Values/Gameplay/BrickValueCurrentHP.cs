namespace Grimmz
{
    public class BrickValueCurrentHP : BrickValue
    {
        private Unit Unit;

        public override int Return => Unit.CurrentHP;
    }
}
