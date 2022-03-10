
using RiseOfKingdoms.Commander;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfKingdoms.Characteristic.Infantry
{
    internal class Snare_of_Thorns : CharacterBase
    {
        public override void BeforeAction(CommanderBase at, CommanderBase df)
        {
            df.tempSpeedIncrease -= actionAmount;
        }

        public override void AfterAction(CommanderBase at, CommanderBase df)
        {
            Random random = new Random();

            if (actionCount == 0)
                actionAmount = 0;

            if (df.normalAttackDamage > 0 && random.Next(0, 10) == 0 && actionCount <= 0)
            {
                actionAmount = (5 * Count);
                actionCount = 2;
            }

            actionCount--;
        }
    }
}
