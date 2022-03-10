﻿using RiseOfKingdoms.Commander;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiseOfKingdoms.Calculate;
using RiseOfKingdoms.Common;

namespace RiseOfKingdoms.Skill
{
    internal class Dragon_Lancer : SkillBase
    {

        public double extraDamage;
        public override void Active(CommanderBase at, CommanderBase df)
        {
            // 75 계수 스킬
            extraDamage = CalcDamage.CalcActiveSkillDamage(at, df, 75);
            if (UsingLog.usingLog == true)
                Console.WriteLine("@스킬시전 {0}", extraDamage);
            AddAfterSkillBonus(at, 1, 2, ActiveBonus);
        }

        public void ActiveBonus(CommanderBase at, CommanderBase df)
        {
            CalcDamage.CalcAdditionalSkillDamage(df, extraDamage);
            if (UsingLog.usingLog == true)
                Console.WriteLine("@추가스킬시전 {0}", extraDamage);
        }

        public override void Passive1Before(CommanderBase at, CommanderBase df)
        {
        }
        public override void Passive1After(CommanderBase at, CommanderBase df)
        {
            // 기병이속 10퍼 증가
        }

        public override void Passive2Before(CommanderBase at, CommanderBase df)
        {
        }
        public override void Passive2After(CommanderBase at, CommanderBase df)
        {
            // 기병 공격력 5퍼 증가   
        }

        public override void Passive3Before(CommanderBase at, CommanderBase df)
        {
        }
        public override void Passive3After(CommanderBase at, CommanderBase df)
        {
            // 기병 방어력 5퍼 증가
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
