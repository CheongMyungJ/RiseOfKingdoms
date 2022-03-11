
using RiseOfKingdoms.Commander;
using RiseOfKingdoms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfKingdoms.Equip.Legendary
{
    internal class Moras_Web : EquipmentBase
    {
        public override void BeforeAction(CommanderBase at, CommanderBase df)
        {
            df.tempDefence -= actionAmount;
            df.tempSpeedIncrease -= actionAmount2;
        }

        double actionAmount2 = 0;
        public override void AfterAction(CommanderBase at, CommanderBase df)
        {
            if (actionCount == 0)
                actionAmount = 0;

            Random random = new Random();
            if (df.normalAttackDamage > 0 && random.Next(0, 10) < 3)
            {
                actionAmount += (isStrengthen ? 5.5 : 4);
                actionAmount = Math.Min(actionAmount, (isStrengthen ? 16.5 : 12));
                actionAmount2 += (isStrengthen ? 10.5 : 8);
                actionAmount2 = Math.Min(actionAmount2, (isStrengthen ? 31.5 : 24));
                if (UsingLog.usingLog == true)
                    Console.WriteLine("- {0}[모라의 거미줄] 대상 부대 방어력 {1}% 감소. 대상 부대 이동속도 {2}% 감소. 3초 지속", at.site, actionAmount, actionAmount2);
                actionCount = 3;
            }
            actionCount--;
        }
    }
}
