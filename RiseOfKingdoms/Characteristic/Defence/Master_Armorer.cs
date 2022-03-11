
using RiseOfKingdoms.Commander;
using RiseOfKingdoms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfKingdoms.Characteristic.Defence
{
    internal class Master_Armorer : CharacterBase
    {
        public override void BeforeAction(CommanderBase at, CommanderBase df)
        {
            at.tempDefence += actionAmount;
        }

        public override void AfterAction(CommanderBase at, CommanderBase df)
        {
            actionAmount = (3 * Count);
            if (UsingLog.usingLog == true)
                Console.WriteLine("- {0}[병기공장인] 부대 방어력 {1}% 증가", at.site, actionAmount);
        }
    }
}
