
using RiseOfKingdoms.Commander;
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
            at.tempAdditionalSkillDamageIncrease += actionAmount;
        }

        public override void AfterAction(CommanderBase at, CommanderBase df)
        {
            //잠재력 추가스킬피해 6증가
        }
    }
}
