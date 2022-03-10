
using RiseOfKingdoms.Commander;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfKingdoms.Characteristic.Archer
{
    internal class Thumb_Ring : CharacterBase
    {
        public override void BeforeAction(CommanderBase at, CommanderBase df)
        {
            if (at.armyType == CommanderBase.ArmyType.Archer && df.armyType == CommanderBase.ArmyType.Infantry)
                actionAmount = (3 * Count);
            else if (at.armyType == CommanderBase.ArmyType.Mixed && df.armyType == CommanderBase.ArmyType.Infantry)
                actionAmount = (1 * Count);
            else if (at.armyType == CommanderBase.ArmyType.Archer && df.armyType == CommanderBase.ArmyType.Mixed)
                actionAmount = (1 * Count);
            else if (at.armyType == CommanderBase.ArmyType.Mixed && df.armyType == CommanderBase.ArmyType.Mixed)
                actionAmount = ((1/3) * Count);

            at.tempDamageIncrease += actionAmount;
        }

        public override void AfterAction(CommanderBase at, CommanderBase df)
        {
        }
    }
}
