
using RiseOfKingdoms.Commander;
using RiseOfKingdoms.Common;
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
                if (UsingLog.usingLog == true)
                    Console.WriteLine("- {0}[현상유지] 받는 피해 {1}% 감소. 2초 지속", at.site, actionAmount);
                actionCount = 2;
            }

            actionCount--;
        }
    }
}
