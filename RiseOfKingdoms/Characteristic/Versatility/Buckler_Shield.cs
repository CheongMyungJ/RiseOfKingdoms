
using RiseOfKingdoms.Commander;
using RiseOfKingdoms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfKingdoms.Characteristic.Versatility
{
    internal class Buckler_Shield : CharacterBase
    {
        public override void BeforeAction(CommanderBase at, CommanderBase df)
        {
            at.tempDamageDecrease += actionAmount;
        }

        public override void AfterAction(CommanderBase at, CommanderBase df)
        {
            if (at.battleState == CommanderBase.BattleState.Conquering)
            {
                actionAmount = (1 * Count);
                if (UsingLog.usingLog == true)
                    Console.WriteLine("- {0}[원형방패] 받는 피해 {1}% 감소", at.site, actionAmount);
            }
        }
    }
}
