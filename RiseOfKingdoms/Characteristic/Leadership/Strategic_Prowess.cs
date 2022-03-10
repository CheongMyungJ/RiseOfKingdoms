
using RiseOfKingdoms.Commander;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfKingdoms.Characteristic.Leadership
{
    internal class Strategic_Prowess : CharacterBase
    {
        public override void BeforeAction(CommanderBase at, CommanderBase df)
        {
            at.tempDefence += actionAmount;
        }

        public override void AfterAction(CommanderBase at, CommanderBase df)
        {
            if (actionCount == 0)
                actionAmount = 0;
            if (at.isSkillUsed == true)
            {
                actionAmount = (5 * Count);
                actionCount = 2;
            }
            actionCount--;
        }
    }
}
