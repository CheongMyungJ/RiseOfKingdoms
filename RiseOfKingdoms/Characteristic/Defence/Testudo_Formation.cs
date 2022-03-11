
using RiseOfKingdoms.Commander;
using RiseOfKingdoms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfKingdoms.Characteristic.Defence
{
    internal class Testudo_Formation : CharacterBase
    {
        public override void BeforeAction(CommanderBase at, CommanderBase df)
        {
            at.tempDamageDecrease += actionAmount;
        }

        public override void AfterAction(CommanderBase at, CommanderBase df)
        {
            if (actionCount == 0)
                actionAmount = 0;

            Random random = new Random();
            if (df.normalAttackDamage > 0 && random.Next(0, 10) == 0)
            {
                actionAmount = (5 * Count);
                if (UsingLog.usingLog == true)
                    Console.WriteLine("- {0}[귀갑진형] 받는 모든 피해 {1}% 감소. 1초 지속", at.site, actionAmount);
                actionCount = 1;
            }
            actionCount--;
        }
    }
}
