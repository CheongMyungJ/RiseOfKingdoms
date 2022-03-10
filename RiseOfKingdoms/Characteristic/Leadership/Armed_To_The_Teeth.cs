
using RiseOfKingdoms.Commander;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfKingdoms.Characteristic.Leadership
{
    internal class Armed_To_The_Teeth : CharacterBase
    {
        public override void BeforeAction(CommanderBase at, CommanderBase df)
        {
            actionAmount = (1 * Count);
            if (at.armyType == CommanderBase.ArmyType.Mixed)
                at.tempDamageDecrease += actionAmount;
        }

        public override void AfterAction(CommanderBase at, CommanderBase df)
        {
        }
    }
}
