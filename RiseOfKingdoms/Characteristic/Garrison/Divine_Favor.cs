
using RiseOfKingdoms.Calculate;
using RiseOfKingdoms.Commander;
using RiseOfKingdoms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfKingdoms.Characteristic.Garrison
{
    internal class Divine_Favor : CharacterBase
    {
        public override void BeforeAction(CommanderBase at, CommanderBase df)
        {
        }

        public override void AfterAction(CommanderBase at, CommanderBase df)
        {
            // 거점수성시 공격받으면 10퍼확률로 500계수 방패
            if (at.battleState == CommanderBase.BattleState.Garrison)
            {
                if (actionCount == 0)
                    actionAmount = 0;
                Random random = new Random();
                if (at.normalAttackDamage > 0 && random.Next(0, 10) == 0)
                {
                    actionAmount = (100 * Count);
                    if (UsingLog.usingLog == true)
                        Console.Write("- {0}[신의 은혜]", at.site);
                    CalcDamage.CalcShieldEffect(at, actionAmount, 1);
                    actionCount = 1;
                }
                actionCount--;
            }
        }
        public void CharacterBonus(CommanderBase at, CommanderBase df)
        {

        }
    }
}
