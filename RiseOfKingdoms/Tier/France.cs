using RiseOfKingdoms.Commander;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfKingdoms.Tier
{
    internal class France : TierBase
    {
        public override void Init(CommanderBase commander)
        {
            commander.baseAttack = 221;
            commander.baseDefence = 212;
            commander.baseHealth = 227;
            commander.armyType = CommanderBase.ArmyType.Infantry;
        }
    }
}
