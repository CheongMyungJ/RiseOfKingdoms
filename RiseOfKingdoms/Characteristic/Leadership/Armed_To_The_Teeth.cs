
using RiseOfKingdoms.Commander;
using RiseOfKingdoms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfKingdoms.Characteristic.Leadership
{
    internal class Armed_To_The_Teeth : CharacterBase
    {
        public override void BeforeAction(CommanderBase at, CommanderBase df)
        {
            actionAmount = (1 * Count);
            if (at.armyType == CommanderBase.ArmyType.Mixed)
            {
                at.tempDamageDecrease += actionAmount;
                if (UsingLog.usingLog == true)
                    Console.WriteLine("- {0}[전원 방패] 받는 모든 피해 {1}% 감소", at.site, actionAmount);
            }
        }

        public override void AfterAction(CommanderBase at, CommanderBase df)
        {
        }
    }
}
