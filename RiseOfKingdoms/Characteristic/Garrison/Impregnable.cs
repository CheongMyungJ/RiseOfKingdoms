
using RiseOfKingdoms.Commander;
using RiseOfKingdoms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfKingdoms.Characteristic.Garrison
{
    internal class Impregnable : CharacterBase
    {
        public override void BeforeAction(CommanderBase at, CommanderBase df)
        {
            if (at.battleState == CommanderBase.BattleState.Garrison)
            {
                actionAmount = (5 * Count);
                if (UsingLog.usingLog == true)
                    Console.WriteLine("- {0}[난공불락] 받는 스킬피해 {1}% 감소", at.site, actionAmount);
                at.tempSkillDamageDecrease += actionAmount;
            }
        }

        public override void AfterAction(CommanderBase at, CommanderBase df)
        {
        }
    }
}
