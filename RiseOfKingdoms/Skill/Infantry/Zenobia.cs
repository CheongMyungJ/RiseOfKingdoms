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
    internal class Zenobia : SkillBase
    {
        double actionAmount0_2 = 0;
        public override void ActiveBefore(CommanderBase at, CommanderBase df)
        {
            at.tempHealth += actionAmount0;
            at.tempDamageIncrease += actionAmount0_2;
 
            actionCount0--;
            if (actionCount0 == 1)
                actionAmount0 *= 2;
            if (actionCount0 == 0)
                actionAmount0 = 0;
        }

        double heal;
        public override void Active(CommanderBase at, CommanderBase df)
        {
            // 주변잔여병력퍼센트 가장낮은 한 아군부대(통솔부대포함)을 치료하며(300계수)
            // 다음1턴간 통솔부대를 추가로 치료합니다(계수1100)
            // 치료된 부대는 2초간 생명력이 지속적으로 50퍼 증가하며 입히는 모든 피해 30퍼 증가
            CalcDamage.CalcHealingEffect(at, df, 300);
            if (UsingLog.usingLog == true)
                Console.WriteLine("@치료스킬시전 {0}", heal);
            at.isSkillUsed = true;

            actionAmount0 = 50;
            actionAmount0_2 = 30;
            actionCount0 = 2;
        }
        public void ActiveBonus(CommanderBase at, CommanderBase df)
        {
            CalcDamage.CalcHealingEffect(at, df, 1100);
            if (UsingLog.usingLog == true)
                Console.WriteLine("@치료스킬시전 {0}", heal);
        }


        public override void Passive1Before(CommanderBase at, CommanderBase df)
        {
            if (at.battleState == CommanderBase.BattleState.Garrison)
            {
                actionAmount1 = 15;
                at.tempNormalDamageDecrease += actionAmount1;
                at.tempNormalDamageIncrease += actionAmount1;
            }
        }
        public override void Passive1After(CommanderBase at, CommanderBase df)
        {
            // 거점방어시 일반공격피해 15퍼감소, 일반공격피해 15퍼증가
        }

        public override void Passive2Before(CommanderBase at, CommanderBase df)
        {
            if (df.battleState == CommanderBase.BattleState.Conquering)
            {
                actionAmount2 = 10;
                at.tempDamageIncrease += actionAmount2;
            }
        }
        public override void Passive2After(CommanderBase at, CommanderBase df)
        {
            // 보병생20 공 20증가. 집결부대에 피해 10퍼증가
        }

        public override void Passive3Before(CommanderBase at, CommanderBase df)
        {
        }
        public override void Passive3After(CommanderBase at, CommanderBase df)
        {
            // 주둔중 공격시 10퍼확률로 대상부대에게 초당피해(600계수)3초지속 5초에한번발동
            if (at.battleState == CommanderBase.BattleState.Garrison && df.normalAttackDamage > 0 && actionCount3 <= 0)
            {
                actionAmount3 = 600;
                double Damage = CalcDamage.CalcActiveSkillDamage(at, df, actionAmount3);
                if (UsingLog.usingLog == true)
                    Console.WriteLine("@추가스킬시전 {0}", Damage);
                AddAfterSkillBonus(at, 0, 2, Passive3Bonus);
                actionCount3 = 5;
            }
            actionCount3--;
        }
        public void Passive3Bonus(CommanderBase at, CommanderBase df)
        {
            double Damage = CalcDamage.CalcActiveSkillDamage(at, df, actionAmount3);
            if (UsingLog.usingLog == true)
                Console.WriteLine("@추가스킬시전 {0}", Damage);
        }

        public override void NewBefore(CommanderBase at, CommanderBase df)
        {
        }
        public override void NewAfter(CommanderBase at, CommanderBase df)
        {
        }
    }
}