
using RiseOfKingdoms.Commander;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfKingdoms.Characteristic.Mobility
{
    internal class Time_Management : CharacterBase
    {
        public override void BeforeAction(CommanderBase at, CommanderBase df)
        {
            at.tempSpeedIncrease -= actionAmount;
        }

        public override void AfterAction(CommanderBase at, CommanderBase df)
        {
            actionAmount = (2 * Count);
        }
    }
}
