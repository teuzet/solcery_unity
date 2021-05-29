using UnityEngine;

namespace Grimmz
{
    public class BrickValueRandomRange : BrickValue
    {
        private BrickValue Start;
        private BrickValue End;

        public override int Return => Random.Range(Start.Return, End.Return + 1);
    }
}
