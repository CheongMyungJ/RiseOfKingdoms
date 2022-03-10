
using RiseOfKingdoms.Commander;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfKingdoms.Characteristic.Support
{
    internal class Counterattack : CharacterBase
    {
        public override void BeforeAction(CommanderBase at, CommanderBase df)
        {
            at.tempAttack += actionAmount;
        }

        public override void AfterAction(CommanderBase at, CommanderBase df)
        {
            if (actionCount == 0)
                actionAmount = 0;
            if (at.heal > 0)
            {
                actionAmount = (3 * Count);
                actionCount = 3;
            }
            actionCount--;

        }
    }
}
