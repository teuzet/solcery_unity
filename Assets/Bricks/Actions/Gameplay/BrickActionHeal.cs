using UnityEngine;

namespace Grimmz
{
    public class BrickActionHeal : BrickActionUnit
    {
        private BrickValue Amount;

        public override void Do()
        {
            Debug.Log("Heals unit for amount of HP");

            Unit.Heal(Amount.Return);
        }
    }
}
