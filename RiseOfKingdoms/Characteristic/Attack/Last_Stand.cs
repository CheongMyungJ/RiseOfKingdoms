
using RiseOfKingdoms.Commander;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfKingdoms.Characteristic.Attack
{
    internal class Last_Stand : CharacterBase
    {
        public override void BeforeAction(CommanderBase at, CommanderBase df)
        {
            at.tempDamageIncrease += actionAmount;
        }

        public override void AfterAction(CommanderBase at, CommanderBase df)
        {
            if (actionCount == 0)
                actionAmount = 0;
            Random random = new Random();
            if (df.normalAttackDamage > 0 && random.Next(0, 10) == 0 && actionCount <= 0)
            {
                actionAmount = (2 * Count);
                actionCount = 3;
                at.silenceTurn = 4;
            }
            actionCount--;
        }
    }
}
