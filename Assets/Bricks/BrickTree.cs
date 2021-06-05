namespace Grimmz
{
    public class BrickTree
    {
        // picture int
        // string name
        // string desc

        public BrickData Genesis { get; private set; }

        public void SetGenesis(BrickData data)
        {
            Genesis = data;
        }

        public string Serialize()
        {
            return "card";
        }
    }

    public struct BrickMetadata
    {

    }
}
