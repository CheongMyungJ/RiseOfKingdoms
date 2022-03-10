
using RiseOfKingdoms.Commander;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfKingdoms.Characteristic.Infantry
{
    internal class Hold_The_Line : CharacterBase
    {
        public override void BeforeAction(CommanderBase at, CommanderBase df)
        {
            at.tempDamageDecrease += actionAmount;
        }

        public override void AfterAction(CommanderBase at, CommanderBase df)
        {
            Random random = new Random();

            if (actionCount == 0)
                actionAmount = 0;

            if (at.normalAttackDamage > 0 && random.Next(0, 10) == 0 && actionCount <= 0 && at.armyType == CommanderBase.ArmyType.Infantry)
            {
                actionAmount = (5 * Count);
                actionCount = 2;
            }

            actionCount--;
        }
    }
}
