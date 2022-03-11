
using RiseOfKingdoms.Commander;
using RiseOfKingdoms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfKingdoms.Equip.Epic
{
    internal class Silent_Trial : EquipmentBase
    {
        public override void BeforeAction(CommanderBase at, CommanderBase df)
        {
        }

        public override void AfterAction(CommanderBase at, CommanderBase df)
        {
            if (df.normalAttackDamage > 0)
            {
                actionAmount = (isStrengthen ? 13 : 10);
                if (UsingLog.usingLog == true)
                    Console.WriteLine("- {0}[고요한 심판] 대상 부대 분노 {1}% 감소", at.site, actionAmount);
                df.rageMinus += actionAmount;
            }
        }
    }
}
