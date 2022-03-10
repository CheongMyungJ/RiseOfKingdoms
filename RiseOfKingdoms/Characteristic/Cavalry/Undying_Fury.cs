
using RiseOfKingdoms.Commander;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfKingdoms.Characteristic.Cavalry
{
    internal class Undying_Fury : CharacterBase
    {
        public override void BeforeAction(CommanderBase at, CommanderBase df)
        {
        }

        public override void AfterAction(CommanderBase at, CommanderBase df)
        {
            if (df.normalAttackDamage > 0)
            {
                actionAmount = (3 * Count);
                at.ragePlus += actionAmount;
            }
        }
    }
}
