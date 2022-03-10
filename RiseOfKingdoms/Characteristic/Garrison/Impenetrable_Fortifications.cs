
using RiseOfKingdoms.Commander;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfKingdoms.Characteristic.Garrison
{
    internal class Impenetrable_Fortifications : CharacterBase
    {
        public override void BeforeAction(CommanderBase at, CommanderBase df)
        {
            if (at.battleState == CommanderBase.BattleState.Garrison)
            {
                actionAmount = (2 * Count);
                at.tempDamageDecrease += actionAmount;
            }
        }

        public override void AfterAction(CommanderBase at, CommanderBase df)
        {
        }
    }
}
