using RiseOfKingdoms.Commander;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfKingdoms.Tier
{
    internal class Arabia : TierBase
    {
        public override void Init(CommanderBase commander)
        {
            commander.baseAttack = 227;
            commander.baseDefence = 212;
            commander.baseHealth = 222;
            commander.armyType = CommanderBase.ArmyType.Cavalry;
        }
    }
}
