
using RiseOfKingdoms.Commander;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfKingdoms.Characteristic.Leadership
{
    internal class Name_Of_The_King : CharacterBase
    {
        public override void BeforeAction(CommanderBase at, CommanderBase df)
        {
            if (at.battleState == CommanderBase.BattleState.Conquering)
            {
                actionAmount = (1 * Count);
                at.tempAttack += actionAmount;
            }
        }

        public override void AfterAction(CommanderBase at, CommanderBase df)
        {
        }
    }
}
