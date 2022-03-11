
using RiseOfKingdoms.Commander;
using RiseOfKingdoms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfKingdoms.Characteristic.Attack
{
    internal class Lord_of_War : CharacterBase
    {
        public override void BeforeAction(CommanderBase at, CommanderBase df)
        {
            at.tempAttack += actionAmount;
        }

        public override void AfterAction(CommanderBase at, CommanderBase df)
        {
            actionAmount = (3 * Count);
            if (UsingLog.usingLog == true)
                Console.WriteLine("- {0}[전쟁의왕] 부대 공격력 {1}% 증가", at.site, actionAmount);
        }
    }
}
