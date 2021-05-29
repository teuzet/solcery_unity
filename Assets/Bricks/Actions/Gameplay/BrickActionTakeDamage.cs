using UnityEngine;

namespace Grimmz
{
    public class BrickActionTakeDamage : BrickActionUnit
    {
        private BrickValue Amount;

        public override void Do()
        {
            Debug.Log("Deals amount of damage to unit");

            Unit.TakeDamage(Amount.Return);
        }
    }
}

