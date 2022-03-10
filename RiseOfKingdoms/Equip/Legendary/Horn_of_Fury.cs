
using RiseOfKingdoms.Commander;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfKingdoms.Equip.Legendary
{
    internal class Horn_of_Fury : EquipmentBase
    {
        public override void BeforeAction(CommanderBase at, CommanderBase df)
        {
        }

        double actionAmount2 = 0;
        public override void AfterAction(CommanderBase at, CommanderBase df)
        {
            Random random = new Random();
            if (df.normalAttackDamage > 0 && random.Next(0, 10) < 3)
            {
                actionAmount = (isStrengthen ? 65 : 50);
                at.ragePlus += actionAmount;
            }
        }
    }
}
