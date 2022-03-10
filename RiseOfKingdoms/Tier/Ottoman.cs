using RiseOfKingdoms.Commander;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfKingdoms.Tier
{
    internal class Ottoman : TierBase
    {
        public override void Init(CommanderBase commander)
        {
            commander.baseAttack = 227;
            commander.baseDefence = 216;
            commander.baseHealth = 216;
            commander.armyType = CommanderBase.ArmyType.Archer;
        }
    }
}
