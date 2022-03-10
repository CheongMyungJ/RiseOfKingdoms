

using RiseOfKingdoms.Calculate;
using RiseOfKingdoms.Commander;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfKingdoms.Characteristic.Archer
{
    internal class Phoenix_Tail_Arrows : CharacterBase
    {
        public override void BeforeAction(CommanderBase at, CommanderBase df)
        {
        }

        public override void AfterAction(CommanderBase at, CommanderBase df)
        {
            if (at.armyType == CommanderBase.ArmyType.Archer)
            {
                Random random = new Random();
                if (df.normalAttackDamage > 0 && random.Next(0, 10) == 0)
                    CalcDamage.CalcActiveSkillDamage(at, df, (50 * Count));
            }
                
        }
    }
}
