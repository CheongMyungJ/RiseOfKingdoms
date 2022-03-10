
using RiseOfKingdoms.Commander;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfKingdoms.Characteristic.Versatility
{
    internal class Turn_Of_Fate : CharacterBase
    {
        public override void BeforeAction(CommanderBase at, CommanderBase df)
        {
            if (actionType == 0)
                at.tempAttack += actionAmount;
            else if (actionType == 1)
                at.tempDefence -= actionAmount;
            else if (actionType == 2)
                at.tempDamageIncrease += actionAmount;
            else if (actionType == 3)
                at.tempSpeedIncrease -= actionAmount;
        }

        int actionType = 0;
        public override void AfterAction(CommanderBase at, CommanderBase df)
        {
            if (actionCount == 0)
                actionAmount = 0;
            if (actionCount <= 0)
            {
                Random random = new Random();
                actionType = random.Next(0,4);
                actionAmount = (1 * Count);
                actionCount = 5;
            }
            actionCount--;
        }
    }
}
