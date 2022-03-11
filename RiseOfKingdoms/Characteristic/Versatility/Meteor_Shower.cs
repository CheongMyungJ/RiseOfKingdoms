
using RiseOfKingdoms.Commander;
using RiseOfKingdoms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfKingdoms.Characteristic.Versatility
{
    internal class Meteor_Shower : CharacterBase
    {
        public override void BeforeAction(CommanderBase at, CommanderBase df)
        {
            at.tempDamageIncrease += actionAmount;
        }

        public override void AfterAction(CommanderBase at, CommanderBase df)
        {
            if (at.battleState == CommanderBase.BattleState.Conquering)
            {
                actionAmount = (1 * Count);
                if (UsingLog.usingLog == true)
                    Console.WriteLine("- {0}[축복의눈물] 모든 피해 {1}% 증가", at.site, actionAmount);
            }
        }
    }
}
