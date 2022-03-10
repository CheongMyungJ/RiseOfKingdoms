using RiseOfKingdoms.Commander;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfKingdoms.Tier
{
    internal class China : TierBase
    {
        public override void Init(CommanderBase commander)
        {
            commander.baseAttack = 227;
            commander.baseDefence = 222;
            commander.baseHealth = 212;
            commander.armyType = CommanderBase.ArmyType.Archer;
        }
    }
}
