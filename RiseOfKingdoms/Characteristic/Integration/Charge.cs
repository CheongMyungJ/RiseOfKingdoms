
using RiseOfKingdoms.Commander;
using RiseOfKingdoms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfKingdoms.Characteristic.Integration
{
    internal class Charge : CharacterBase
    {
        public override void BeforeAction(CommanderBase at, CommanderBase df)
        {
            at.tempSpeedIncrease += actionAmount;
        }

        public override void AfterAction(CommanderBase at, CommanderBase df)
        {
            if (at.troop * 2 <= at.maxTroop)
            {
                if (at.armyType == CommanderBase.ArmyType.Cavalry)
                    actionAmount = (3 * Count);
                else if (at.armyType == CommanderBase.ArmyType.Mixed)
                    actionAmount = (1 * Count);

                if (UsingLog.usingLog == true)
                    Console.WriteLine("- {0}[전속돌격] 기마병 이동속도 {1}% 증가", at.site, 3 * Count);
            }

        }
    }
}
