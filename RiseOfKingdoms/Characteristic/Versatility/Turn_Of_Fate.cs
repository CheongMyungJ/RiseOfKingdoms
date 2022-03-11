
using RiseOfKingdoms.Commander;
using RiseOfKingdoms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfKingdoms.Characteristic.Versatility
{
    internal class Turn_Of_Fate : CharacterBase
    {
        public override void BeforeAction(CommanderBase at, CommanderBase df)
        {
            if (actionType == 0)
            {
                at.tempAttack += actionAmount;
                if (UsingLog.usingLog == true)
                    Console.WriteLine("- {0}[운명의 전환] 부대 공격력 {1}% 증가", at.site, actionAmount);
            }
            else if (actionType == 1)
            {
                at.tempDefence -= actionAmount;
                if (UsingLog.usingLog == true)
                    Console.WriteLine("- {0}[운명의 전환] 부대 방어력 {1}% 감소", at.site, actionAmount);
            }
            else if (actionType == 2)
            {
                at.tempDamageIncrease += actionAmount;
                if (UsingLog.usingLog == true)
                    Console.WriteLine("- {0}[운명의 전환] 모든 피해 {1}% 증가", at.site, actionAmount);
            }
            else if (actionType == 3)
            {
                at.tempSpeedIncrease -= actionAmount;
                if (UsingLog.usingLog == true)
                    Console.WriteLine("- {0}[운명의 전환] 이동속도 {1}% 감소", at.site, actionAmount);
            }
        }

        int actionType = 0;
        public override void AfterAction(CommanderBase at, CommanderBase df)
        {
            if (actionCount == 0)
                actionAmount = 0;
            if (actionCount <= 0)
            {
                Random random = new Random();
                actionType = random.Next(0,4);
                actionAmount = (1 * Count);
                actionCount = 5;
            }
            actionCount--;
        }
    }
}
