using RiseOfKingdoms.Commander;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfKingdoms.Tier
{
    internal class Spain : TierBase
    {
        public override void Init(CommanderBase commander)
        {
            commander.baseAttack = 232;
            commander.baseDefence = 212;
            commander.baseHealth = 216;
            commander.armyType = CommanderBase.ArmyType.Cavalry;
        }
    }
}
