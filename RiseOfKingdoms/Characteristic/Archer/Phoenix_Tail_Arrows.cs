

using RiseOfKingdoms.Calculate;
using RiseOfKingdoms.Commander;
using RiseOfKingdoms.Common;
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
                {
                    actionAmount = (50 * Count);
                    if (UsingLog.usingLog == true)
                        Console.Write("- {0}[봉황선]", at.site);
                    CalcDamage.CalcActiveSkillDamage(at, df, actionAmount);
                }
                    
            }
                
        }
    }
}
