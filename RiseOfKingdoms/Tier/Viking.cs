using RiseOfKingdoms.Commander;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfKingdoms.Tier
{
    internal class Viking : TierBase
    {
        public override void Init(CommanderBase commander)
        {
            commander.baseAttack = 221;
            commander.baseDefence = 216;
            commander.baseHealth = 222;
            commander.armyType = CommanderBase.ArmyType.Infantry;
        }
    }
}
