
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
    internal class Artemisia : SkillBase
    {
        public override void ActiveBefore(CommanderBase at, CommanderBase df)
        {
        }

        public override void Active(CommanderBase at, CommanderBase df)
        {
            // 피해계수 1800, 나에게 피해계수 300
            if (UsingLog.usingLog == true)
                Console.Write("- {0}[살라미스 전투]", at.site);
            CalcDamage.CalcActiveSkillDamage(at, df, 1800);
            if (UsingLog.usingLog == true)
                Console.Write("- {0}[살라미스 전투]", at.site);
            CalcDamage.CalcActiveSkillDamage(at, at, 300);

            at.isSkillUsed = true;
        }


        public override void Passive1Before(CommanderBase at, CommanderBase df)
        {       
        }
        public override void Passive1After(CommanderBase at, CommanderBase df)
        {
            // 궁병방생 20증가
        }

        public override void Passive2Before(CommanderBase at, CommanderBase df)
        {
            if (at.battleState == CommanderBase.BattleState.Garrison)
            {
                actionAmount2 = 10;
                at.tempNormalDamageDecrease += actionAmount2;
            }
        }
        public override void Passive2After(CommanderBase at, CommanderBase df)
        {
            // 주둔시 일반공격피해 10퍼감소, 일반공격시 10퍼확률로 1초간 금수효과(일반공격불가)
            if (at.battleState == CommanderBase.BattleState.Garrison)
            {
                Random random = new Random();
                if (df.normalAttackDamage > 0 && random.Next(0, 10) == 0)
                {
                    if (UsingLog.usingLog == true)
                        Console.WriteLine("- {0}[크세르크세스의 맹우] 대상부대에 금수효과 1초 지속", at.site);
                    df.forbiddenTurn = 2;
                }
            }
        }

        bool togle = true;
        public override void Passive3Before(CommanderBase at, CommanderBase df)
        {
            at.tempDamageIncrease += actionAmount3;
        }
        public override void Passive3After(CommanderBase at, CommanderBase df)
        {
            if (at.isSkillUsed == true)
                togle = true;

            // 분노 80퍼까지 증가하면 50퍼 확률로 3초 자체침묵, 모든피해 50퍼 증가 5초지속
            if (actionCount3 == 0)
                actionAmount3 = 0;

            Random random = new Random();
            if (at.rage >= at.maxRage * 0.8)
            {
                if (togle == true && random.Next(0, 2) == 0)
                {
                    if (UsingLog.usingLog == true)
                        Console.WriteLine("- {0}[카리아 여왕] 대상 부대에 3초 침묵, 통솔부대 피해 50% 증가 5초 지속", at.site);
                    if (at.silenceTurn <= 1)
                        at.silenceTurn = 4;
                    actionAmount3 = 50;
                    actionCount3 = 5;
                }
                togle = false;
            }
            actionCount3--;
        }

        double actionAmountNew_2 = 0;
        public override void NewBefore(CommanderBase at, CommanderBase df)
        {
            df.tempSkillDamageIncrease += actionAmountNew;
        }
        public override void NewAfter(CommanderBase at, CommanderBase df)
        {
            // 일반공격시 10퍼확률로 400계수피해 + 상대 스킬피해 15퍼증가 3초지속
            if (actionCountNew == 0)
                actionAmountNew = 0;
            Random random = new Random();
            if (df.normalAttackDamage > 0 && random.Next(0, 10) == 0 && actionCountNew <= 0)
            {
                if (UsingLog.usingLog == true)
                    Console.Write("- {0}[생존의 법칙]", at.site);
                actionAmountNew_2 = CalcDamage.CalcActiveSkillDamage(at, df, 400);
                AddAfterSkillBonus(at, 0, 2, NewBonus);

                if (UsingLog.usingLog == true)
                    Console.WriteLine("- {0}[생존의 법칙] 대상 부대의 스킬피해 15% 증가. 3초 지속", at.site);
                actionAmountNew = 15;
                actionCountNew = 3;
            }
            actionCountNew--;
        }
        public void NewBonus(CommanderBase at, CommanderBase df)
        {
            if (UsingLog.usingLog == true)
                Console.Write("- {0}[생존의 법칙]", at.site);
            CalcDamage.CalcAdditionalSkillDamage(df, actionAmountNew_2);
        }
    }
}
