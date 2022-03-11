
using RiseOfKingdoms.Commander;
using RiseOfKingdoms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfKingdoms.Characteristic.Skill
{
    internal class Latent_Power : CharacterBase
    {
        public override void BeforeAction(CommanderBase at, CommanderBase df)
        {
            actionAmount = (2 * Count);
            if (UsingLog.usingLog == true)
                Console.WriteLine("- {0}[잠재력] 추가스킬피해 {1}% 증가", at.site, actionAmount);
            at.tempAdditionalSkillDamageIncrease += actionAmount;
        }

        public override void AfterAction(CommanderBase at, CommanderBase df)
        {
            //잠재력 추가스킬피해 6증가
        }
    }
}
