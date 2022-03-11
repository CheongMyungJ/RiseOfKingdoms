
using RiseOfKingdoms.Commander;
using RiseOfKingdoms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfKingdoms.Characteristic.Cavalry
{
    internal class Rallying_Cry : CharacterBase
    {
        public override void BeforeAction(CommanderBase at, CommanderBase df)
        {
            if (actionCount == 0)
                actionAmount = 0;

            if (actionCount > 0)
                actionAmount = (3 * Count);

            if (actionAmount > 0)
            {
                if (UsingLog.usingLog == true)
                    Console.WriteLine("- {0}[사기진작] 모든 피해 {1}% 증가", at.site, actionAmount);
            }
            at.tempDamageIncrease += actionAmount;

            actionCount--;
        }

        new int actionCount = 10;
        public override void AfterAction(CommanderBase at, CommanderBase df)
        {
            // 전투 시작 후 10초간 (3*Count)만큼 모든피해 증가.
        }
    }
}
