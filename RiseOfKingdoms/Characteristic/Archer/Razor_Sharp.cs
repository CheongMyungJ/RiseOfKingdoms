
using RiseOfKingdoms.Commander;
using RiseOfKingdoms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfKingdoms.Characteristic.Archer
{
    internal class Razor_Sharp : CharacterBase
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
                    Console.WriteLine("- {0}[예리한 화살촉] 분노 {1} 회복", at.site, actionAmount);
                at.ragePlus += actionAmount;
            }
        }
    }
}
