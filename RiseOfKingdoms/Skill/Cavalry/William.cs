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
    internal class William : SkillBase
    {
        bool actionBool = false;
        public override void ActiveBefore(CommanderBase at, CommanderBase df)
        {
            df.tempSkillDamageIncreaseCancel = actionBool;
            df.tempSpeedIncrease -= actionAmount0;

            actionCount0--;

            if (actionCount0 == 0)
            {
                actionBool = false;
                actionAmount0 = 0;
            }
        }

        bool togle = true;
        public override void Active(CommanderBase at, CommanderBase df)
        {
            // 1500 계수 스킬
            if (UsingLog.usingLog == true)
                Console.Write("- {0}[혈통의 비밀]", at.site);
             CalcDamage.CalcActiveSkillDamage(at, df, 1500);
            
            at.isSkillUsed = true;
            togle = !togle;

            if (UsingLog.usingLog == true)
                Console.WriteLine("- {0}[혈통의 비밀] 대상 부대 스킬피해 증가 버프 금지 행군속도 30% 감소. 3초 지속", at.site);
            actionBool = true;
            actionAmount0 = 30;
            actionCount0 = 3;
        }


        public override void Passive1Before(CommanderBase at, CommanderBase df)
        {
            at.tempDamageIncrease += actionAmount1;
        }
        public override void Passive1After(CommanderBase at, CommanderBase df)
        {
            // 기마공 20퍼 기마이속 15퍼 연맹영토밖에서 모든피해 10퍼증가
            if (at.battleState == CommanderBase.BattleState.Field || at.battleState == CommanderBase.BattleState.Conquering)
                actionAmount1 = 10;
        }

        public override void Passive2Before(CommanderBase at, CommanderBase df)
        {
            at.tempAttack += actionAmount2;
        }
        public override void Passive2After(CommanderBase at, CommanderBase df)
        {
            // 필드에서 기마공 30퍼증가 일반공격시 10퍼확률로 1000계수데미지.
            if (at.battleState == CommanderBase.BattleState.Field || at.battleState == CommanderBase.BattleState.Conquering)
            {
                actionAmount2 = 30;
                Random random = new Random();
                if (random.Next(0, 10) == 0)
                {
                    if (UsingLog.usingLog == true)
                        Console.Write("- {0}[노르만 정복]", at.site);
                    CalcDamage.CalcActiveSkillDamage(at, df, 1000);
                }
            }
        }

        bool togle2 = true;
        public override void Passive3Before(CommanderBase at, CommanderBase df)
        {
            at.tempDefence += actionAmount3;

        }
        public override void Passive3After(CommanderBase at, CommanderBase df)
        {
            if (actionCount3 == 0)
                actionAmount3 = 0;

            // 액티브스킬명중시 부대방어력 20퍼증가 3초지속.
            if (togle != togle2)
            {
                if (UsingLog.usingLog == true)
                    Console.WriteLine("- {0}[북방의 재난] 부대 방어력 20% 증가. 3초 지속", at.site);
                togle2 = togle;
                actionAmount3 = 20;
                actionCount3 = 3;
            }

            actionCount3--;
        }

        public override void NewBefore(CommanderBase at, CommanderBase df)
        {
        }
        public override void NewAfter(CommanderBase at, CommanderBase df)
        {
        }
    }
}
