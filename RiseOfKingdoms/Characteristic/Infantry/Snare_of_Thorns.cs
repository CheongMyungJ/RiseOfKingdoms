
using RiseOfKingdoms.Commander;
using RiseOfKingdoms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfKingdoms.Characteristic.Infantry
{
    internal class Snare_of_Thorns : CharacterBase
    {
        public override void BeforeAction(CommanderBase at, CommanderBase df)
        {
            df.tempSpeedIncrease -= actionAmount;
        }

        public override void AfterAction(CommanderBase at, CommanderBase df)
        {
            Random random = new Random();

            if (actionCount == 0)
                actionAmount = 0;

            if (df.normalAttackDamage > 0 && random.Next(0, 10) == 0 && actionCount <= 0)
            {
                actionAmount = (5 * Count);
                if (UsingLog.usingLog == true)
                    Console.WriteLine("- {0}[가시의 덫] 대상 부대 이동속도 {1}% 감소. 2초 지속", at.site, actionAmount);
                actionCount = 2;
            }

            actionCount--;
        }
    }
}
