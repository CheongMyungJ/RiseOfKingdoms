
using RiseOfKingdoms.Commander;
using RiseOfKingdoms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfKingdoms.Characteristic.Infantry
{
    internal class Elite_Soldiers : CharacterBase
    {
        public override void BeforeAction(CommanderBase at, CommanderBase df)
        {
            if (at.armyType == CommanderBase.ArmyType.Infantry)
            {
                actionAmount = (0.5 * Count);
            }
            if (UsingLog.usingLog == true)
                Console.WriteLine("- {0}[정예부대] 보병 공격력, 방어력, 생명력 {1}% 증가", at.site, actionAmount);
            df.tempAttack += actionAmount;
            df.tempDefence += actionAmount;
            df.tempHealth += actionAmount;
        }

        public override void AfterAction(CommanderBase at, CommanderBase df)
        {
        }
    }
}
