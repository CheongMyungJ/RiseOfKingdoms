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
    internal class Chandragupta_Maurya : SkillBase
    {
        public override void ActiveBefore(CommanderBase at, CommanderBase df)
        {
            at.tempDamageIncrease += actionAmount0;

            actionCount0--;
            actionCount0_2--;
           
            if (actionCount0 == 0)
                actionAmount0 = 0;
            if (actionCount0_2 == 0)
                actionAmount0_2 = 0;
        }

        double actionAmount0_2 = 0;
        double actionCount0_2 = 0;
        bool togle = true;
        public override void Active(CommanderBase at, CommanderBase df)
        {
            // 스킬시전후 3초간 모든피해 40증가. 축복효과 1회 획득. 10초지속 4한도
            if (UsingLog.usingLog == true)
                Console.WriteLine("- {0}[월호왕] 축복효과 1회 획득. 모든 피해 40% 증가. 3초 지속", at.site);
            actionAmount0_2 += 1;
            actionAmount0_2 = Math.Min(4, actionAmount0_2);
            actionCount0_2 = 10;

            actionAmount0 = 40;
            actionCount0 = 3;
            togle = !togle;

            at.isSkillUsed = true;
        }

        public override void Passive1Before(CommanderBase at, CommanderBase df)
        {
            if (at.battleState == CommanderBase.BattleState.Conquering)
            {
                actionAmount1 = 10;
                at.tempDamageDecrease += actionAmount1;
            }
        }
        bool togle2 = true;
        public override void Passive1After(CommanderBase at, CommanderBase df)
        {
            // 거점공격시 받피감 10퍼. 스킬시전시 축복효과 1회 추가획득
            if (at.battleState == CommanderBase.BattleState.Conquering)
            {
                if (togle != togle2)
                {
                    if (UsingLog.usingLog == true)
                        Console.WriteLine("- {0}[황실 코끼리] 축복효과 1회 획득", at.site);
                    togle2 = togle;
                    actionAmount0_2 += 1;
                    actionAmount0_2 = Math.Min(4, actionAmount0_2);
                    actionCount0_2 = 10;
                }
            }
        }

        double actionAmount2_2 = 0;
        public override void Passive2Before(CommanderBase at, CommanderBase df)
        {
            if (at.armyType == CommanderBase.ArmyType.Cavalry)
            {
                actionAmount2 = 20;
                at.tempHealth += actionAmount2;
                df.tempHealth -= actionAmount2_2;
                df.tempDefence -= actionAmount2_2;
            }
        }
        public override void Passive2After(CommanderBase at, CommanderBase df)
        {
            // 올기병이면 생명력 20퍼증가. 매회 50퍼 확률로 대상 생,방 5퍼감소 3회중첩 5초지속
            if (at.armyType == CommanderBase.ArmyType.Cavalry)
            {
                if (actionCount2 == 0)
                    actionAmount2_2 = 0;

                Random random = new Random();
                if (random.Next(0, 2) == 0)
                {
                    actionAmount2_2 += 5;
                    actionAmount2_2 = Math.Min(15, actionAmount2_2);
                    if (UsingLog.usingLog == true)
                        Console.WriteLine("- {0}[정사론] 탈진효과 {0}%", actionAmount2_2, at.site);
                    actionCount2 = 5;
                }
                actionCount2--;
            }   
        }

        public override void Passive3Before(CommanderBase at, CommanderBase df)
        {
            if (df.armyType == CommanderBase.ArmyType.Cavalry)
            {
                actionAmount3 = 5;
                at.tempDamageDecrease += actionAmount3;
            }
            at.tempSpeedIncrease += actionAmount3_2;
        }
        double actionAmount3_2 = 0;
        double skillDamage = 0;
        public override void Passive3After(CommanderBase at, CommanderBase df)
        {
            // 기병에게 받는 피해 5퍼감소 스킬시전시 3초간 행속 25퍼증가. 스킬시전시 대상에게 500*축복효과 피해
            if (actionCount3 == 0)
                actionAmount3_2 = 0;
            if (at.isSkillUsed == true && actionCount3 <= 0)
            {
                actionAmount3_2 = 25;
                actionCount3 = 3;
                if (UsingLog.usingLog == true)
                    Console.Write("- {0}[고행]", at.site);
                CalcDamage.CalcActiveSkillDamage(at, df, 500 * actionAmount0_2);
                actionAmount0_2 = 0;
            }
            actionCount3--;
        }

        public override void NewBefore(CommanderBase at, CommanderBase df)
        {
        }
        public override void NewAfter(CommanderBase at, CommanderBase df)
        {
            // 연맹영토내에서 공격시 50퍼 확률로 축복효과 1회획득. 외에서 공격시 2회획득 5초에 한번발동
            Random random = new Random();
            if (df.normalAttackDamage > 0 && random.Next(0, 2) == 0 && actionCountNew <= 0)
            {
                if (at.battleState == CommanderBase.BattleState.Garrison)
                {
                    if (UsingLog.usingLog == true)
                        Console.WriteLine("- {0}[마우리야 왕조] 축복효과 1회 획득", at.site);
                    actionAmount0_2 += 1;
                }
                else
                {
                    if (UsingLog.usingLog == true)
                        Console.WriteLine("- {0}[마우리야 왕조] 축복효과 2회 획득", at.site);
                    actionAmount0_2 += 2;
                }   

                actionAmount0_2 = Math.Min(4, actionAmount0_2);
                actionCount0_2 = 10;
                actionCountNew = 5;
            }
            actionCountNew--;
        }
    }
}
