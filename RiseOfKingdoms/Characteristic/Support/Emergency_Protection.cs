
using RiseOfKingdoms.Commander;
using RiseOfKingdoms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfKingdoms.Characteristic.Support
{
    internal class Emergency_Protection : CharacterBase
    {
        public override void BeforeAction(CommanderBase at, CommanderBase df)
        {
            at.tempSkillDamageDecrease += actionAmount;
        }

        public override void AfterAction(CommanderBase at, CommanderBase df)
        {
            if (actionCount == 0)
                actionAmount = 0;
            Random random = new Random();
            if (random.Next(0, 10) < 5 && actionCount <= 0 && at.skillDamage > 0)
            {
                actionAmount = (5 * Count);
                if (UsingLog.usingLog == true)
                    Console.WriteLine("- {0}[긴급방어] 스킬피해 {1}% 감소", at.site, actionAmount);
                actionCount = 3;
            }
            actionCount--;
        }
    }
}
