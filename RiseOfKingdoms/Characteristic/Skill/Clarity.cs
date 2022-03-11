
using RiseOfKingdoms.Commander;
using RiseOfKingdoms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfKingdoms.Characteristic.Skill
{
    internal class Clarity : CharacterBase
    {
        public override void BeforeAction(CommanderBase at, CommanderBase df)
        {
            at.tempSkillDamageIncrease += actionAmount;
        }

        public override void AfterAction(CommanderBase at, CommanderBase df)
        {
            //명료 스킬시전시 6초간 스킬피해 6증가
            if (actionCount == 0)
                actionAmount = 0;

            if (at.isSkillUsed == true)
            {
                actionAmount = (2 * Count);
                if (UsingLog.usingLog == true)
                    Console.WriteLine("- {0}[명료] 스킬피해 {1}% 증가. 6초 지속", at.site, actionAmount);
                actionCount = 6;

            }
            actionCount--;
        }
    }
}
