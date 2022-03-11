
using RiseOfKingdoms.Commander;
using RiseOfKingdoms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfKingdoms.Characteristic.Versatility
{
    internal class Nowhere_To_Turn : CharacterBase
    {
        public override void BeforeAction(CommanderBase at, CommanderBase df)
        {
        }

        public override void AfterAction(CommanderBase at, CommanderBase df)
        {
            if (at.battleState == CommanderBase.BattleState.Garrison)
            {
                if (at.normalAttackDamage > 0)
                {
                    actionAmount = (2 * Count);
                    if (UsingLog.usingLog == true)
                        Console.WriteLine("- {0}[사면초가] 분노 {1} 회복", at.site, actionAmount);
                    at.ragePlus += actionAmount;
                }
            }
        }
    }
}
