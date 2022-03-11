
using RiseOfKingdoms.Calculate;
using RiseOfKingdoms.Commander;
using RiseOfKingdoms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfKingdoms.Characteristic.Defence
{
    internal class Medicinal_Supplies : CharacterBase
    {
        public override void BeforeAction(CommanderBase at, CommanderBase df)
        {
            
        }

        public override void AfterAction(CommanderBase at, CommanderBase df)
        {
            if (at.isSkillUsed == true)
            {
                actionAmount = (100 * Count);
                if (UsingLog.usingLog == true)
                    Console.Write("- {0}[약초준비]", at.site);
                CalcDamage.CalcHealingEffect(at, df, actionAmount);
            }
        }
    }
}
