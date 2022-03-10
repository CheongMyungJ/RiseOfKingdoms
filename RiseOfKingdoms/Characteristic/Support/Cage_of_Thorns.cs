
using RiseOfKingdoms.Commander;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfKingdoms.Characteristic.Support
{
    internal class Cage_of_Thorns : CharacterBase
    {
        public override void BeforeAction(CommanderBase at, CommanderBase df)
        {
            df.tempSpeedIncrease -= actionAmount;
        }

        public override void AfterAction(CommanderBase at, CommanderBase df)
        {
            if (actionCount == 0)
                actionAmount = 0;

            if (at.isSkillUsed)
            {
                actionAmount = (5 * Count);
                actionCount = 3;
            }
            actionCount--;
        }
    }
}
