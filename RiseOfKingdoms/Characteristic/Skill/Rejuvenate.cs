
using RiseOfKingdoms.Commander;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfKingdoms.Characteristic.Skill
{
    internal class Rejuvenate : CharacterBase
    {
        public override void BeforeAction(CommanderBase at, CommanderBase df)
        {
        }

        public override void AfterAction(CommanderBase at, CommanderBase df)
        {
            //인내 스킬시전시 분노 60회복
            if (at.isSkillUsed == true)
            {
                actionAmount = (20 * Count);
                at.ragePlus += actionAmount;
            }
        }
    }
}
