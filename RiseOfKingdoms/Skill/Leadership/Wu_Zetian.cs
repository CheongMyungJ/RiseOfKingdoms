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
    internal class Wu_Zetian : SkillBase
    {
        public override void ActiveBefore(CommanderBase at, CommanderBase df)
        {
        }

        public override void Active(CommanderBase at, CommanderBase df)
        {
            // 피해계수 1000, 치료 500계수
            if (UsingLog.usingLog == true)
                Console.Write("- {0}[용동봉경]", at.site);
            CalcDamage.CalcActiveSkillDamage(at, df, 1000);

            if (UsingLog.usingLog == true)
                Console.Write("- {0}[용동봉경]", at.site);
            CalcDamage.CalcHealingEffect(at, df, 500);

            at.isSkillUsed = true;
        }


        public override void Passive1Before(CommanderBase at, CommanderBase df)
        {
            if (at.battleState == CommanderBase.BattleState.Garrison)
            {
                actionAmount1 = 10;
                at.tempDamageIncrease += actionAmount1;
            }
            if (df.battleState == CommanderBase.BattleState.Conquering)
            {
                actionAmount1 = 10;
                at.tempDamageIncrease += actionAmount1;
            }
        }
        public override void Passive1After(CommanderBase at, CommanderBase df)
        {
            // 거점주둔시 모든피해 10퍼증가. 집결부대에 피해 10퍼증가.
        }

        public override void Passive2Before(CommanderBase at, CommanderBase df)
        {
        }
        public override void Passive2After(CommanderBase at, CommanderBase df)
        {
            // 통솔부대 방어생명 10퍼증가. 공격당할시 10퍼확률로 적부대 2초간 침묵
            Random random = new Random();
            if (at.normalAttackDamage > 0 && random.Next(0, 10) == 0)
            {
                if (UsingLog.usingLog == true)
                    Console.WriteLine("- {0}[붉은 눈물] 대상 부대 2초간 침묵", at.site);
                AddAfterSkillBonus(at, 0, 1, Passive2Bonus);
            }
        }
        public void Passive2Bonus(CommanderBase at, CommanderBase df)
        {
            if (df.silenceTurn <= 1)
                df.silenceTurn = 3;
        }

        double actionAmount3_2 = 0;
        public override void Passive3Before(CommanderBase at, CommanderBase df)
        {
            if (at.battleState == CommanderBase.BattleState.Garrison)
            {
                actionAmount3 = 15;
                at.tempSkillDamageDecrease += actionAmount3;
            }
            at.tempDefence += actionAmount3_2;
        }
        public override void Passive3After(CommanderBase at, CommanderBase df)
        {
            // 거점주둔시 받는스킬피해 15퍼감소, 스킬피해받을때 50퍼확률로 3초간 방어 20증가
            if (at.battleState == CommanderBase.BattleState.Garrison)
            {
                if (actionCount3 == 0)
                    actionAmount3_2 = 0;

                Random random = new Random();
                if (at.skillDamage > 0 && random.Next(0, 2) == 0)
                {
                    if (UsingLog.usingLog == true)
                        Console.WriteLine("- {0}[무자 비석] 부대 방어력 20% 증가. 3초 지속", at.site);
                    actionAmount3_2 = 20;
                    actionCount3 = 3;
                }
                actionCount3--;
            }   
        }

        public override void NewBefore(CommanderBase at, CommanderBase df)
        {
        }
        public override void NewAfter(CommanderBase at, CommanderBase df)
        {
            // 반격피해 20퍼증가. 공격받을때 10퍼확률로 피해계수 500
            Random random = new Random();
            if (at.normalAttackDamage > 0 && random.Next(0, 10) == 0)
            {
                if (UsingLog.usingLog == true)
                    Console.Write("- {0}[여왕 만세]", at.site);
                CalcDamage.CalcActiveSkillDamage(at, df, 500);
            }
        }
    }
}
