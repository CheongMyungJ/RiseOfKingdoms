
using RiseOfKingdoms.Commander;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfKingdoms.Equip.Legendary
{
    internal class Concealed_Dagger : EquipmentBase
    {
        public override void BeforeAction(CommanderBase at, CommanderBase df)
        {
            df.tempHealth -= actionAmount;
        }

        public override void AfterAction(CommanderBase at, CommanderBase df)
        {
            if (actionCount == 0)
                actionAmount = 0;

            Random random = new Random();
            if (df.normalAttackDamage > 0 && random.Next(0, 10) < 3)
            {
                actionAmount += (isStrengthen ? 6.5 : 5);
                actionAmount = Math.Min(actionAmount, (isStrengthen ? 19.5 : 15));
                actionCount = 3;
            }
            actionCount--;
        }
    }
}
