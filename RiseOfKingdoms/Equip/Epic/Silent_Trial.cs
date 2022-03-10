﻿
using RiseOfKingdoms.Commander;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfKingdoms.Equip.Epic
{
    internal class Silent_Trial : EquipmentBase
    {
        public override void BeforeAction(CommanderBase at, CommanderBase df)
        {
        }

        public override void AfterAction(CommanderBase at, CommanderBase df)
        {
            if (df.normalAttackDamage > 0)
            {
                actionAmount = (isStrengthen ? 13 : 10);
                df.rageMinus += actionAmount;
            }
        }
    }
}
