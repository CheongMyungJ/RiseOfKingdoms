
using RiseOfKingdoms.Commander;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfKingdoms.Characteristic.Garrison
{
    internal class Impregnable : CharacterBase
    {
        public override void BeforeAction(CommanderBase at, CommanderBase df)
        {
            if (at.battleState == CommanderBase.BattleState.Garrison)
            {
                actionAmount = (5 * Count);
                at.tempSkillDamageDecrease += actionAmount;
            }
        }

        public override void AfterAction(CommanderBase at, CommanderBase df)
        {
        }
    }
}
