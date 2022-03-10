using RiseOfKingdoms.Commander;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiseOfKingdoms.Calculate;
using RiseOfKingdoms.Common;

namespace RiseOfKingdoms.Skill
{
    internal class Markswoman : SkillBase
    {
        public double extraDamage;
        public override void Active(CommanderBase at, CommanderBase df)
        {
            // 100 계수 스킬
            extraDamage = CalcDamage.CalcActiveSkillDamage(at, df, 100);
            if (UsingLog.usingLog == true)
                Console.WriteLine("@스킬시전 {0}", extraDamage);
        }

        public override void Passive1Before(CommanderBase at, CommanderBase df)
        {
        }
        public override void Passive1After(CommanderBase at, CommanderBase df)
        {
            // 야만인 피해 10퍼 증가
        }

        public override void Passive2Before(CommanderBase at, CommanderBase df)
        {
        }
        public override void Passive2After(CommanderBase at, CommanderBase df)
        {
            // 궁병 공격력 5퍼 증가   
        }

        public override void Passive3Before(CommanderBase at, CommanderBase df)
        {
        }
        public override void Passive3After(CommanderBase at, CommanderBase df)
        {
            // 궁병 방어력 5퍼 증가
        }

        public override void NewBefore(CommanderBase at, CommanderBase df)
        {
        }
        public override void NewAfter(CommanderBase at, CommanderBase df)
        {
            // 각성스킬 없음
        }
    }
}
