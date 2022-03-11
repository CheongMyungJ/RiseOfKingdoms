
using RiseOfKingdoms.Commander;
using RiseOfKingdoms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfKingdoms.Equip.Legendary
{
    internal class Ring_of_Doom : EquipmentBase
    {
        public override void BeforeAction(CommanderBase at, CommanderBase df)
        {
            at.tempDamageIncrease += actionAmount;
        }

        public override void AfterAction(CommanderBase at, CommanderBase df)
        {
            if (actionCount == 3)
                actionAmount = 0;
            Random random = new Random();
            if (df.normalAttackDamage > 0 && random.Next(0, 10) == 0 && actionCount <= 0)
            {
                actionAmount = (isStrengthen ? 65 : 50);
                if (UsingLog.usingLog == true)
                    Console.WriteLine("- {0}[심판의 반지] 모든 피해 {1}% 증가. 2초 지속", at.site, actionAmount);
                actionCount = 5;
            }
            actionCount--;
        }
    }
}
