
using RiseOfKingdoms.Commander;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfKingdoms.Characteristic.Integration
{
    internal class Armored_To_The_Teeth : CharacterBase
    {
        public override void BeforeAction(CommanderBase at, CommanderBase df)
        {
            if (at.armyType == CommanderBase.ArmyType.Mixed)
                actionAmount = (1 * Count);
            at.tempDamageDecrease += actionAmount;
        }

        public override void AfterAction(CommanderBase at, CommanderBase df)
        {
            
        }
    }
}
