
using RiseOfKingdoms.Commander;
using RiseOfKingdoms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfKingdoms.Characteristic.Infantry
{
    internal class Call_of_the_Pack : CharacterBase
    {
        public override void BeforeAction(CommanderBase at, CommanderBase df)
        {
            at.tempDefence += actionAmount;
        }

        public override void AfterAction(CommanderBase at, CommanderBase df)
        {
            if (at.troop * 2 <= at.maxTroop)
            {
                actionAmount = (2 * Count);
                if (UsingLog.usingLog == true)
                    Console.WriteLine("- {0}[무리의부름] 부대 방어력 {1}% 증가", at.site, actionAmount);
            }
                
        }
    }
}
