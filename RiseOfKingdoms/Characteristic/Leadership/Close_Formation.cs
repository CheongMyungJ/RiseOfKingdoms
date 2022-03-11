
using RiseOfKingdoms.Commander;
using RiseOfKingdoms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfKingdoms.Characteristic.Leadership
{
    internal class Close_Formation : CharacterBase
    {
        public override void BeforeAction(CommanderBase at, CommanderBase df)
        {
            at.tempAttack += actionAmount;
        }

        public override void AfterAction(CommanderBase at, CommanderBase df)
        {
            if (at.troop * 2 <= at.maxTroop)
            {
                actionAmount = (3 * Count);
                if (UsingLog.usingLog == true)
                    Console.WriteLine("- {0}[밀집진형] 부대 공격력 {1}% 증가", at.site, actionAmount);
            }
                
        }
    }
}
