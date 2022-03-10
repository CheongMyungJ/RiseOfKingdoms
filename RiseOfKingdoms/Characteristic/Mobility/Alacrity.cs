
using RiseOfKingdoms.Commander;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfKingdoms.Characteristic.Mobility
{
    internal class Alacrity : CharacterBase
    {
        public override void BeforeAction(CommanderBase at, CommanderBase df)
        {
            // 이속저하디버프 30프로 확률로 방어 어떻게 구현할지 고민..
            Random random = new Random();
            if (random.Next(0, 10) < 3 && at.tempSpeedIncrease < 0)
            {
                at.tempSpeedIncrease = 0;
            }
        }

        public override void AfterAction(CommanderBase at, CommanderBase df)
        {
        }
    }
}
