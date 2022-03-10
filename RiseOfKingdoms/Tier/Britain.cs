using RiseOfKingdoms.Commander;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfKingdoms.Tier
{
    internal class Britain : TierBase
    {
        public override void Init(CommanderBase commander)
        {
            commander.baseAttack = 232;
            commander.baseDefence = 216;
            commander.baseHealth = 211;
            commander.armyType = CommanderBase.ArmyType.Archer;
        }
    }
}
