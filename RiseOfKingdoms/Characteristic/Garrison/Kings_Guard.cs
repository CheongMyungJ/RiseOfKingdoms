
using RiseOfKingdoms.Commander;
using RiseOfKingdoms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfKingdoms.Characteristic.Garrison
{
    internal class Kings_Guard : CharacterBase
    {
        public override void BeforeAction(CommanderBase at, CommanderBase df)
        {
            if (at.battleState == CommanderBase.BattleState.Garrison)
            {
                actionAmount = (1 * Count);
                if (UsingLog.usingLog == true)
                    Console.WriteLine("- {0}[왕궁호위대] 부대 공격력,방어력,생명력 {1}% 증가", at.site, actionAmount);
                at.tempAttack += actionAmount;
                at.tempDefence += actionAmount;
                at.tempHealth += actionAmount;
            }
        }

        public override void AfterAction(CommanderBase at, CommanderBase df)
        {
        }
    }
}
