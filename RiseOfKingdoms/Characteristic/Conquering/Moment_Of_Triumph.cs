
using RiseOfKingdoms.Commander;
using RiseOfKingdoms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfKingdoms.Characteristic.Conquering
{
    internal class Moment_Of_Triumph : CharacterBase
    {
        public override void BeforeAction(CommanderBase at, CommanderBase df)
        {
            at.tempDamageIncrease += actionAmount;
        }

        public override void AfterAction(CommanderBase at, CommanderBase df)
        {
            if (at.troop >= at.maxTroop * 0.9)
            {
                actionAmount = (3 * Count);
                if (UsingLog.usingLog == true)
                    Console.WriteLine("- {0}[승기] 모든 피해 {1}% 증가", at.site, actionAmount);
            }
        }
    }
}
