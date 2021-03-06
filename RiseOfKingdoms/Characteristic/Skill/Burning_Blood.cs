
using RiseOfKingdoms.Commander;
using RiseOfKingdoms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfKingdoms.Characteristic.Skill
{
    internal class Burning_Blood : CharacterBase
    {
        public override void BeforeAction(CommanderBase at, CommanderBase df)
        {
        }

        public override void AfterAction(CommanderBase at, CommanderBase df)
        {
            //분노의일격 일반공격 분노 9
            if (df.normalAttackDamage > 0)
            {
                actionAmount = (3 * Count);
                if (UsingLog.usingLog == true)
                    Console.WriteLine("- {0}[분노의일격] 분노 {1} 회복", at.site, actionAmount);
                at.ragePlus += actionAmount;
            }
        }
    }
}
