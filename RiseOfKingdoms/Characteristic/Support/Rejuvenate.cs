
using RiseOfKingdoms.Commander;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfKingdoms.Characteristic.Support
{
    internal class Rejuvenate : CharacterBase
    {
        public override void BeforeAction(CommanderBase at, CommanderBase df)
        {
        }

        public override void AfterAction(CommanderBase at, CommanderBase df)
        {
            if (at.isSkillUsed)
            {
                actionAmount = (50 * Count);
                at.ragePlus += actionAmount;
            }
        }
    }
}
