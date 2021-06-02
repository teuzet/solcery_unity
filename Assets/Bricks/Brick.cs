using Sirenix.OdinInspector;

namespace Grimmz
{
    public abstract class Brick<TReturn> : Brick
    {
        public abstract TReturn Return { get; }
    }

    public abstract class Brick : SerializedScriptableObject
    {
        protected Context Context { get; }
    }
}
