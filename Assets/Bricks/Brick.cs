namespace Grimmz
{
    public abstract class Brick<TReturn> : Brick
    {
        public TReturn Output { get; protected set; }
    }

    public abstract class Brick
    {

    }
}
