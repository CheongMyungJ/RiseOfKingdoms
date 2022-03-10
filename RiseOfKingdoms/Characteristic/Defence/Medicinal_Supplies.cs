
using RiseOfKingdoms.Calculate;
using RiseOfKingdoms.Commander;
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
                CalcDamage.CalcHealingEffect(at, df, actionAmount);
            }
        }
    }
}
