
using RiseOfKingdoms.Commander;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfKingdoms.Characteristic.Attack
{
    internal class Lord_of_War : CharacterBase
    {
        public override void BeforeAction(CommanderBase at, CommanderBase df)
        {
            at.tempAttack += actionAmount;
        }

        public override void AfterAction(CommanderBase at, CommanderBase df)
        {
            actionAmount = (3 * Count);
        }
    }
}
