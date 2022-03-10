using RiseOfKingdoms.Commander;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfKingdoms.Tier
{
    internal class Germany : TierBase
    {
        public override void Init(CommanderBase commander)
        {
            commander.baseAttack = 220;
            commander.baseDefence = 217;
            commander.baseHealth = 222;
            commander.armyType = CommanderBase.ArmyType.Cavalry;
        }
    }
}
