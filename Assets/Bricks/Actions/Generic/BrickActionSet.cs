using System.Collections.Generic;
using UnityEngine;

namespace Grimmz
{
    public class BrickActionSet : BrickAction
    {
        private List<BrickAction> Actions;

        public override void Do()
        {
            Debug.Log("Runs all containing actions one by one");

            for (int i = 0; i < Actions.Count; i++)
            {
                Actions[i].Do();
            }
        }
    }
}
