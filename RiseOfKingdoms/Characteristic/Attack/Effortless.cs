
using RiseOfKingdoms.Commander;
using RiseOfKingdoms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfKingdoms.Characteristic.Attack
{
    internal class Effortless : CharacterBase
    {
        public override void BeforeAction(CommanderBase at, CommanderBase df)
        {
            at.tempDamageIncrease += actionAmount;
        }

        Dictionary<int, double> effectDic = new Dictionary<int, double> { { 1, 0.5 }, { 2, 1 }, { 3, 2.5 } };
        public override void AfterAction(CommanderBase at, CommanderBase df)
        {
            if (actionCount == 0)
            {
                actionAmount += effectDic[Count];
                actionAmount = Math.Min(10, actionAmount);
                if (UsingLog.usingLog == true)
                    Console.WriteLine("- {0}[여유] 모든 피해 {1}% 증가", at.site, actionAmount);
                actionCount = 10;
            }
            actionCount--;
        }
    }
}
