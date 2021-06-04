using System;

namespace Grimmz
{
    [Serializable]
    public class BrickTree
    {
        public BrickData Genesis { get; private set; }

        public void SetGenesis(BrickData data)
        {
            Genesis = data;
        }
    }
}
