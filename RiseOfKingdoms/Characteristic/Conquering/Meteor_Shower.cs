
using RiseOfKingdoms.Commander;
using RiseOfKingdoms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfKingdoms.Characteristic.Conquering
{
    internal class Meteor_Shower : CharacterBase
    {
        public override void BeforeAction(CommanderBase at, CommanderBase df)
        {
            at.tempDamageIncrease += actionAmount;
        }

        public override void AfterAction(CommanderBase at, CommanderBase df)
        {
            if (df.battleState == CommanderBase.BattleState.Garrison)
            {
                if (actionCount == 0)
                    actionAmount = 0;
                Random random = new Random();
                if (df.normalAttackDamage > 0 && random.Next(0, 10) == 0)
                {
                    actionAmount = (10 * Count);
                    if (UsingLog.usingLog == true)
                        Console.WriteLine("- {0}[축복의 눈물] 모든 피해 {1}% 증가. 1초 지속", at.site, actionAmount);
                    actionCount = 1;
                }
                actionCount--;
            }
        }
    }
}
