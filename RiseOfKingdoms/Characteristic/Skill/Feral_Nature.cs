
using RiseOfKingdoms.Commander;
using RiseOfKingdoms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfKingdoms.Characteristic.Skill
{
    internal class Feral_Nature : CharacterBase
    {
        public override void BeforeAction(CommanderBase at, CommanderBase df)
        {
        }

        public override void AfterAction(CommanderBase at, CommanderBase df)
        {
            //치명적인자연 일반공격시 10퍼확률 분노 100회복
            Random random = new Random();
            if (df.normalAttackDamage > 0 && random.Next(0, 10) == 0)
            {
                actionAmount = (20 * Count);
                if (UsingLog.usingLog == true)
                    Console.WriteLine("- {0}[치명적인자연] 분노 {1} 회복", at.site, actionAmount);
                at.ragePlus += actionAmount;
            }
        }
    }
}
