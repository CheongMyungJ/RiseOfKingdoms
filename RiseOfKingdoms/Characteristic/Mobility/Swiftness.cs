
using RiseOfKingdoms.Commander;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfKingdoms.Characteristic.Mobility
{
    internal class Swiftness : CharacterBase
    {
        public override void BeforeAction(CommanderBase at, CommanderBase df)
        {
            at.tempSpeedIncrease += actionAmount;
        }

        public override void AfterAction(CommanderBase at, CommanderBase df)
        {
            if (actionCount == 0)
                actionAmount = 0;
            if (at.skillDamage > 0 && actionCount <= 0)
            {
                actionAmount = (5 * Count);
                actionCount = 5;
            }
            actionCount--;
        }
    }
}
