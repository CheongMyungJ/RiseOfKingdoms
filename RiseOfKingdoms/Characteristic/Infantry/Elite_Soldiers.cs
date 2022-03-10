
using RiseOfKingdoms.Commander;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfKingdoms.Characteristic.Infantry
{
    internal class Elite_Soldiers : CharacterBase
    {
        public override void BeforeAction(CommanderBase at, CommanderBase df)
        {
            if (at.armyType == CommanderBase.ArmyType.Infantry)
            {
                actionAmount = (0.5 * Count);
            }
            df.tempAttack += actionAmount;
            df.tempDefence += actionAmount;
            df.tempHealth += actionAmount;
        }

        public override void AfterAction(CommanderBase at, CommanderBase df)
        {
        }
    }
}
