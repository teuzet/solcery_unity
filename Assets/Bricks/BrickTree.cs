namespace Grimmz
{
    public class BrickTree
    {
        public BrickData Genesis { get; private set; }

        public void SetGenesis(BrickData data)
        {
            Genesis = data;
        }
    }
}
