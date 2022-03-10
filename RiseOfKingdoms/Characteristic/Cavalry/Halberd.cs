
using RiseOfKingdoms.Commander;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfKingdoms.Characteristic.Cavalry
{
    internal class Halberd : CharacterBase
    {
        public override void BeforeAction(CommanderBase at, CommanderBase df)
        {
            df.tempAttack -= actionAmount;
        }

        public override void AfterAction(CommanderBase at, CommanderBase df)
        {
            // 일반공격시 10퍼 확률로 5*Count만큼 상대 공격력 감소 2초간 지속.
            if (actionCount == 0)
                actionAmount = 0;

            Random random = new Random();
            if (df.normalAttackDamage > 0 && random.Next(0, 10) == 0 && actionCount <= 0)
            {
                actionAmount = (5 * Count);
                actionCount = 2;
            }
            actionCount--;
        }
    }
}
