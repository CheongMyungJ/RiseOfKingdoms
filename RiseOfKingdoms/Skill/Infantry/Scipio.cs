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
    internal class Scipio : SkillBase
    {
        public override void ActiveBefore(CommanderBase at, CommanderBase df)
        {
            df.tempHealth -= actionAmount0;
 
            actionCount0--;
            if (actionCount0 == 0)
                actionAmount0 = 0;
        }

        public override void Active(CommanderBase at, CommanderBase df)
        {
            // 계수 2000 생명력 30퍼감소 3초
            if (UsingLog.usingLog == true)
                Console.Write("- {0}[무적의 힘]", at.site);
            CalcDamage.CalcActiveSkillDamage(at, df, 2000);
            at.isSkillUsed = true;

            if (UsingLog.usingLog == true)
                Console.WriteLine("- {0}[무적의 힘] 대상 부대 생명력 {1)%감소, {2}초 지속", at.site, actionAmount0, actionCount0);
            actionAmount0 = 30;
            actionCount0 = 3;
        }

        public override void Passive1Before(CommanderBase at, CommanderBase df)
        {
           
        }
        public override void Passive1After(CommanderBase at, CommanderBase df)
        {
            // 보병공40증가  사방 정복
        }

        public override void Passive2Before(CommanderBase at, CommanderBase df)
        {
            if (df.battleState != CommanderBase.BattleState.Garrison)
            {
                actionAmount2 = 20;
                at.tempHealth += actionAmount2;
            }
        }
        double actionAmount2_2 = 0;
        public override void Passive2After(CommanderBase at, CommanderBase df)
        {
            // 대상이 부대이면 보병생명력 20퍼 증가 공격시 10초확률로 3초추가피해(500계수) 8초에한번발동
            if (df.battleState != CommanderBase.BattleState.Garrison)
            {
                Random random = new Random();
                if (random.Next(0, 10) < 1 && actionCount2 <= 0)
                {
                    actionAmount2_2 = CalcDamage.CalcActiveSkillDamage(at, df, 500, false);
                    AddAfterSkillBonus(at, 1, 3, Passive2Bonus);
                    actionCount2 = 8;
                }
                actionCount2--;
            }
        }
        public void Passive2Bonus(CommanderBase at, CommanderBase df)
        {
            if (UsingLog.usingLog == true)
                Console.Write("- {0}[압제의 전략]", at.site);
            CalcDamage.CalcAdditionalSkillDamage(df, actionAmount2_2);
        }

        public override void Passive3Before(CommanderBase at, CommanderBase df)
        {
        }
        public override void Passive3After(CommanderBase at, CommanderBase df)
        {
            Random random = new Random();
            // 필드에서 스킬피해입으면 50퍼확률로 30퍼감소 동시에 3초실드 500계수 8초에한번발동
            if (at.skillDamage > 0 && random.Next(0,2) == 0 && at.battleState != CommanderBase.BattleState.Garrison && actionCount3 <= 0)
            {
                if (UsingLog.usingLog == true)
                    Console.WriteLine("- {0}[갑주 진형] 이번 피해 30%감소", at.site);
                at.skillDamage *= 0.7;

                actionAmount3 = 500;
                if (UsingLog.usingLog == true)
                    Console.Write("- {0}[갑주 진형]", at.site);
                CalcDamage.CalcShieldEffect(at, actionAmount3, 3);
                actionCount3 = 8;
            }
            actionCount3--;
        }

        public override void NewBefore(CommanderBase at, CommanderBase df)
        {
        }
        public override void NewAfter(CommanderBase at, CommanderBase df)
        {
            //스킬피해 10퍼증가 대상침묵이면 분노회복 30퍼증가 불타는 분노
            if (df.silenceTurn > 0)
            {
                actionAmountNew = 30;
                if (UsingLog.usingLog == true)
                    Console.WriteLine("- {0}[불타는 분노] 분노 회복 속도 {1}%증가", at.site, actionAmountNew);
                at.ragePlus *= 1.3;
            }
        }
    }
}
