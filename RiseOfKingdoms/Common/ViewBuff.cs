using RiseOfKingdoms.Commander;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RiseOfKingdoms.Common.Commanders;
using static RiseOfKingdoms.Common.Tiers;

namespace RiseOfKingdoms.Common
{
    internal static class ViewBuff
    {
        public static void ViewAdditionalBuff(CommanderBase at, CommanderBase df)
        {
            Console.WriteLine("▶공격측 버프");
            Console.WriteLine("사령관 : 주 {0},부 {1}", at.commanderClassList[0].Item1.GetType().Name, at.commanderClassList[1].Item1.GetType().Name);
            Console.WriteLine("공격력 : {0}\n방어력 : {1}\n생명력 : {2}\n피해증가 : {3}\n피해감소 : {4}\n스킬피해증가 : {5}\n스킬피해감소 : {6}\n" +
                "일반피해증가 : {7}\n일반피해감소 : {8}\n반격피해증가 : {9}\n반격피해감소 : {10}\n치료효과증가 : {11}\n", at.additionalAttack, at.additionalDefence, at.additionalHealth,
                at.additionalDamageIncrease, at.additionalDamageDecrease, at.additionalSkillDamageIncrease, at.additionalSkillDamageDecrease, at.additionalNormalDamageIncrease,
                at.additionalNormalDamageDecrease, at.additionalCounterDamageIncrease, at.additionalCounterDamageDecrease, at.additionalHealingEffect);
            Console.WriteLine("▶수비측 버프");
            Console.WriteLine("사령관 : 주 {0},부 {1}", df.commanderClassList[0].Item1.GetType().Name, df.commanderClassList[1].Item1.GetType().Name);
            Console.WriteLine("공격력 : {0}\n방어력 : {1}\n생명력 : {2}\n피해증가 : {3}\n피해감소 : {4}\n스킬피해증가 : {5}\n스킬피해감소 : {6}\n" +
                "일반피해증가 : {7}\n일반피해감소 : {8}\n반격피해증가 : {9}\n반격피해감소 : {10}\n치료효과증가 : {11}\n", df.additionalAttack, df.additionalDefence, df.additionalHealth,
                df.additionalDamageIncrease, df.additionalDamageDecrease, df.additionalSkillDamageIncrease, df.additionalSkillDamageDecrease, df.additionalNormalDamageIncrease,
                df.additionalNormalDamageDecrease, df.additionalCounterDamageIncrease, df.additionalCounterDamageDecrease, df.additionalHealingEffect);
        }
       
    }
}
