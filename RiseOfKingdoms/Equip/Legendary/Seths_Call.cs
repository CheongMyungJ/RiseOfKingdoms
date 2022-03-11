
using RiseOfKingdoms.Commander;
using RiseOfKingdoms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfKingdoms.Equip.Legendary
{
    internal class Seths_Call : EquipmentBase
    {
        public override void BeforeAction(CommanderBase at, CommanderBase df)
        {
            at.tempAttack += actionAmount;
        }

        public override void AfterAction(CommanderBase at, CommanderBase df)
        {
            if (actionCount == 0)
                actionAmount = 0;
            Random random = new Random();
            if (df.normalAttackDamage > 0 && random.Next(0, 10) == 0 && actionCount <= 0)
            {
                actionAmount = (isStrengthen ? 13 : 10);
                if (UsingLog.usingLog == true)
                    Console.WriteLine("- {0}[샤이트의 외침] 부대 공격력 {1}% 증가", at.site, actionAmount);
                actionCount = 3;
            }
            actionCount--;
        }
    }
}
