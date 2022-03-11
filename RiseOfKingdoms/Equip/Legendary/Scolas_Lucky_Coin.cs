
using RiseOfKingdoms.Calculate;
using RiseOfKingdoms.Commander;
using RiseOfKingdoms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfKingdoms.Equip.Legendary
{
    internal class Scolas_Lucky_Coin : EquipmentBase
    {
        public override void BeforeAction(CommanderBase at, CommanderBase df)
        {
        }

        double actionAmount2 = 0;
        public override void AfterAction(CommanderBase at, CommanderBase df)
        {
            if (actionCount == 3)
                actionAmount = 0;

            Random random = new Random();
            if (at.normalAttackDamage > 0 && random.Next(0, 10) == 0 && actionCount <= 0)
            {
                actionAmount = (isStrengthen ? 650 : 500);
                if (UsingLog.usingLog == true)
                    Console.Write("- {0}[스콜라스의 행운코인] 방패 {1}계수 발동 ", at.site, actionAmount);
                CalcDamage.CalcShieldEffect(at, actionAmount, 3); 
                actionCount = 3;
            }
            actionCount--;
        }
    }
}
