
using RiseOfKingdoms.Commander;
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
            // 방패 처리해야함.
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
                actionCount = 3;
            }
            actionCount--;
        }
    }
}
