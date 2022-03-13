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
    internal class Zenobia : SkillBase
    {
        public override void ActiveBefore(CommanderBase at, CommanderBase df)
        {
            at.tempHealth += actionAmount0;
 
            actionCount0--;
            if (actionCount0 == 1)
                actionAmount0 *= 2;
            if (actionCount0 == 0)
                actionAmount0 = 0;
        }

        public override void Active(CommanderBase at, CommanderBase df)
        {
            // 주변잔여병력퍼센트 가장낮은 한 아군부대(통솔부대포함)을 치료하며(300계수)
            // 다음1턴간 통솔부대를 추가로 치료합니다(계수1100)
            // 치료된 부대는 2초간 생명력이 지속적으로 50퍼 증가하며 입히는 모든 피해 30퍼 증가
            if (UsingLog.usingLog == true)
                Console.Write("- {0}[팔미라 여왕]", at.site);
            CalcDamage.CalcHealingEffect(at, df, 300);
            at.isSkillUsed = true;
            AddAfterSkillBonus(at, 1, 1, ActiveBonus);
            if (UsingLog.usingLog == true)
                Console.WriteLine("- {0}[팔미라 여왕] 치료된 부대 생명력 지속적으로 50% 증가 모든 피해 30% 증가. 2초 지속", at.site);

            AddBeforeSkillBonus(at, 2, ActiveBonusStart, ActiveBonusEnd);

            actionAmount0 = 50;
            actionCount0 = 2;
        }
        public void ActiveBonus(CommanderBase at, CommanderBase df)
        {
            if (UsingLog.usingLog == true)
                Console.Write("- {0}[팔미라 여왕]", at.site);
            CalcDamage.CalcHealingEffect(at, df, 1100);
        }

        public void ActiveBonusStart(CommanderBase at, CommanderBase df)
        {
            if (at.activeDamageIncrease_bf < 30)
            {
                at.activeDamageIncrease_bf = 30;
            }
        }

        public void ActiveBonusEnd(CommanderBase at, CommanderBase df)
        {
            if (at.activeDamageIncrease_bf == 30)
            {
                at.activeDamageIncrease_bf = 0;
            }
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
                if (UsingLog.usingLog == true)
                    Console.Write("- {0}[다원의 통치]", at.site);
                CalcDamage.CalcActiveSkillDamage(at, df, actionAmount3);
                AddAfterSkillBonus(at, 0, 2, Passive3Bonus);
                actionCount3 = 5;
            }
            actionCount3--;
        }
        public void Passive3Bonus(CommanderBase at, CommanderBase df)
        {
            if (UsingLog.usingLog == true)
                Console.Write("- {0}[다원의 통치]", at.site);
            CalcDamage.CalcActiveSkillDamage(at, df, actionAmount3);
        }

        public override void NewBefore(CommanderBase at, CommanderBase df)
        {
        }
        public override void NewAfter(CommanderBase at, CommanderBase df)
        {
        }
    }
}
