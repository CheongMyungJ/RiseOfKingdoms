
using RiseOfKingdoms.Commander;
using RiseOfKingdoms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfKingdoms.Characteristic.Integration
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
                if (at.armyType == CommanderBase.ArmyType.Infantry)
                    actionAmount = (3 * Count);
                else if (at.armyType == CommanderBase.ArmyType.Mixed)
                    actionAmount = (1 * Count);

                if (UsingLog.usingLog == true)
                    Console.WriteLine("- {0}[무리의부름] 보병 공격력 {1}% 증가", at.site, 3 * Count);
            }
                
        }
    }
}
