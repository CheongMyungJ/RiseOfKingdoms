using RiseOfKingdoms.Commander;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfKingdoms.Tier
{
    internal class Rome : TierBase
    {
        public override void Init(CommanderBase commander)
        {
            commander.baseAttack = 221;
            commander.baseDefence = 222;
            commander.baseHealth = 216;
            commander.armyType = CommanderBase.ArmyType.Infantry;
        }
    }
}
