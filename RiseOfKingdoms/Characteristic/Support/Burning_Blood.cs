﻿
using RiseOfKingdoms.Commander;
using RiseOfKingdoms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfKingdoms.Characteristic.Support
{
    internal class Burning_Blood : CharacterBase
    {
        public override void BeforeAction(CommanderBase at, CommanderBase df)
        {
        }

        public override void AfterAction(CommanderBase at, CommanderBase df)
        {
            if (df.normalAttackDamage > 0)
            {
                actionAmount = (3 * Count);
                if (UsingLog.usingLog == true)
                    Console.WriteLine("- {0}[분노의 일격] 분노 {1} 회복", at.site, actionAmount);
                at.ragePlus += actionAmount;
            }
        }
    }
}
