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
    internal class Theodora : SkillBase
    {
        public override void ActiveBefore(CommanderBase at, CommanderBase df)
        {
        }

        double extraDamage;
        public override void Active(CommanderBase at, CommanderBase df)
        {
            // 피해계수 1700 스킬시전시 디버프 정화
            if (UsingLog.usingLog == true)
                Console.Write("- {0}[비잔틴 황후]", at.site);
            CalcDamage.CalcActiveSkillDamage(at, df, 1700);
            at.isSkillUsed = true;
            if (UsingLog.usingLog == true)
                Console.WriteLine("- {0}[비잔틴 황후] 모든 디버프 제거", at.site);
            // 정화 구현해야함.
        }


        public override void Passive1Before(CommanderBase at, CommanderBase df)
        {
            if (at.battleState == CommanderBase.BattleState.Garrison)
            {
                actionAmount1 = 10;
                at.tempDefence += actionAmount1;
                if (df.battleState == CommanderBase.BattleState.Conquering)
                {
                    actionAmount1 = 10;
                    at.tempDamageDecrease += actionAmount1;
                }
            }
            
            
        }
        public override void Passive1After(CommanderBase at, CommanderBase df)
        {
            // 주둔시 방어력 10퍼증가 집결부대에게 받는피해 10퍼감소
        }

        public override void Passive2Before(CommanderBase at, CommanderBase df)
        {
            at.tempDamageIncrease += actionAmount2;
        }
        public override void Passive2After(CommanderBase at, CommanderBase df)
        {
            // 부대 공격력 10퍼증가 병력 50퍼 이상일때 피해 10퍼증가
            if (at.troop * 2 >= at.maxTroop)
            {
                if (UsingLog.usingLog == true)
                    Console.WriteLine("- {0}[공동 통치자] 모든 피해 10% 증가", at.site);
                actionAmount2 = 10;
            }
        }

        public override void Passive3Before(CommanderBase at, CommanderBase df)
        {
            at.tempDamageIncrease += actionAmount3;

        }
        public override void Passive3After(CommanderBase at, CommanderBase df)
        {
            // 주둔시 공격받으면 10퍼확률로 피해증가 40퍼 3초지속
            if (at.battleState == CommanderBase.BattleState.Garrison)
            {
                if (actionCount3 == 0)
                    actionAmount3 = 0;

                Random random = new Random();
                if (at.normalAttackDamage > 0 && random.Next(0, 10) == 0)
                {
                    if (UsingLog.usingLog == true)
                        Console.WriteLine("- {0}[황실의 권력] 모든 피해 40% 증가. 3초 지속", at.site);
                    actionAmount3 = 40;
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
        }
    }
}
