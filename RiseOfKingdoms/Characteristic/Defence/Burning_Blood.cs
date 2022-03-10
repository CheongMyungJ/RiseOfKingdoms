
using RiseOfKingdoms.Commander;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfKingdoms.Characteristic.Defence
{
    internal class Burning_Blood : CharacterBase
    {
        public override void BeforeAction(CommanderBase at, CommanderBase df)
        {
        }

        public override void AfterAction(CommanderBase at, CommanderBase df)
        {
            if (at.normalAttackDamage > 0)
            {
                actionAmount = (2 * Count);
                at.ragePlus += actionAmount;
            }
        }
    }
}
