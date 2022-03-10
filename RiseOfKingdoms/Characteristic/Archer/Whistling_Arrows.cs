
using RiseOfKingdoms.Commander;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfKingdoms.Characteristic.Archer
{
    internal class Whistling_Arrows : CharacterBase
    {
        public override void BeforeAction(CommanderBase at, CommanderBase df)
        {
            at.tempDamageIncrease += actionAmount;
        }

        public override void AfterAction(CommanderBase at, CommanderBase df)
        {
            if (at.armyType == CommanderBase.ArmyType.Archer)
            {
                if (actionCount == 0)
                    actionAmount = 0;

                Random random = new Random();
                if (df.normalAttackDamage > 0 && random.Next(0, 10) == 0 && actionCount <= 0)
                {
                    actionAmount = (5 * Count);
                    actionCount = 2;
                }
                actionCount--;
            }
        }
    }
}
