
using RiseOfKingdoms.Commander;
using RiseOfKingdoms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfKingdoms.Characteristic.Mobility
{
    internal class Vortex : CharacterBase
    {
        public override void BeforeAction(CommanderBase at, CommanderBase df)
        {
            df.tempSpeedIncrease -= actionAmount;
        }

        public override void AfterAction(CommanderBase at, CommanderBase df)
        {
            if (actionCount == 0)
                actionAmount = 0;
            if (at.isSkillUsed == true && actionCount <= 0)
            {
                Random random = new Random();
                if (random.Next(0, 10) == 0)
                {
                    actionAmount = (5 * Count);
                    if (UsingLog.usingLog == true)
                        Console.WriteLine("- {0}[소용돌이] 대상 부대 이동속도 {1}% 감소. 3초 지속", at.site, actionAmount);
                    actionCount = 3;
                }
            }
            actionCount--;
        }
    }
}
