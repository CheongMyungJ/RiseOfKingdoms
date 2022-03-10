
using RiseOfKingdoms.Commander;
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
