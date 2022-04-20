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
    internal class Gilgamesh : SkillBase
    {
        public override void Active(CommanderBase at, CommanderBase df)
        {
            // 피해계수 1500, 대상부대 생명력 30퍼 감소 3초지속
            if (UsingLog.usingLog == true)
                Console.Write("- {0}[사자의 포효]",at.site);
            CalcDamage.CalcActiveSkillDamage(at, df, 1500);
            
            at.isSkillUsed = true;

            if (UsingLog.usingLog == true)
                Console.WriteLine("- {0}[사자의 포효] 대상부대 생명력 30% 감소 3초 지속", at.site);
            AddBeforeSkillBonus(at, 3, ActiveBonusStart, ActiveBonusEnd);
        }

        public void ActiveBonusStart(CommanderBase at, CommanderBase df)
        {
            if (df.activeHealingEffect_dbf < 30)
            {
                df.activeHealingEffect_dbf = 30;
            }
        }

        public void ActiveBonusEnd(CommanderBase at, CommanderBase df)
        {
            if (df.activeHealingEffect_dbf == 30)
            {
                df.activeHealingEffect_dbf = 0;
            }
        }


        public override void Passive1Before(CommanderBase at, CommanderBase df)
        {
            if (at.armyType == CommanderBase.ArmyType.Archer)
            {
                at.tempDamageIncrease += actionAmount1;
            }
            if (at.armyType == CommanderBase.ArmyType.Mixed)
            {
                at.tempDamageIncrease += (actionAmount1 / 3);
            }
                
        }
        public override void Passive1After(CommanderBase at, CommanderBase df)
        {
            // 궁병생 30증가. 적 부대 50퍼 미만일경우 궁병모든피해 20퍼 증가
            if (df.troop * 2 <= df.maxTroop)
            {
                if (UsingLog.usingLog == true)
                    Console.WriteLine("- {0}[우루크 궁수] 궁병 모든 피해 20% 증가", at.site);
                actionAmount1 = 20;
            }
        }

        double actionAmount2_2 = 0;
        new int actionCount2 = 6;
        public override void Passive2Before(CommanderBase at, CommanderBase df)
        {
            if (df.battleState == CommanderBase.BattleState.Garrison)
            {
                actionAmount2 = 20;
                if (at.armyType == CommanderBase.ArmyType.Archer)
                {
                    at.tempAttack += actionAmount2;
                    at.tempAttack += actionAmount2_2;
                }
                else if (at.armyType == CommanderBase.ArmyType.Mixed)
                {
                    at.tempAttack += (actionAmount2 / 3);
                    at.tempAttack += (actionAmount2_2 / 3);
                }   
            }
        }
        public override void Passive2After(CommanderBase at, CommanderBase df)
        {
            // 도시및거점공격시 궁병공20증가. 6턴마다 공5버프 추가 10초지속 6회중첩
            if (df.battleState == CommanderBase.BattleState.Garrison)
            {
                if (actionCount2 == 0)
                {
                    actionAmount2_2 += 5;
                    actionAmount2_2 = Math.Min(30, actionAmount2_2);
                    if (UsingLog.usingLog == true)
                        Console.WriteLine("- {0}[왕의 법칙] 궁병 공격력 {1}% 증가", at.site, actionAmount2_2);
                    actionCount2 = 6;
                }
                actionCount2--;
            }
        }

        public override void Passive3Before(CommanderBase at, CommanderBase df)
        {
            df.tempSkillDamageDecrease -= actionAmount3;
            if (actionCount3 == 4)
            {
                df.thirstForBloodTurn = 4;
            }
        }
        public override void Passive3After(CommanderBase at, CommanderBase df)
        {
            // 받는 일반피해 15퍼감소. 공격시 30퍼 확률로 4초지속 피의갈증 효과 추가.
            // 대상 부대 치료받을때 고정피해(계수700), 받는 스킬피해 15퍼 증가. 5초에 한번발동
            if (actionCount3 == 1)
            {
                actionAmount3 = 0;
            }   

            Random random = new Random();
            if (df.normalAttackDamage > 0 && random.Next(0, 10) < 3 && actionCount3 <= 0)
            {
                actionAmount3 = 15;
                df.thirstForBloodFactor = 700;
                if (UsingLog.usingLog == true)
                    Console.WriteLine("- {0}[우정의 동행] 대상 부대에 피의갈증 효과 부여. 대상 부대 받는 스킬피해 {1}% 증가. 4초 지속", at.site, actionAmount3);
                actionCount3 = 5;
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
