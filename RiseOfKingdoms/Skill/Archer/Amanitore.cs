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
    internal class Amanitore : SkillBase
    {
        public override void ActiveBefore(CommanderBase at, CommanderBase df)
        {
            at.tempDamageIncrease += actionAmount0;

            actionCount0--;
            if (actionCount0 == 0)
                actionAmount0 = 0;
        }

        
        public override void Active(CommanderBase at, CommanderBase df)
        {
            // 피해계수 1300, 통솔부대 피해 20퍼 증가 3초지속
            if (UsingLog.usingLog == true)
                Console.Write("- {0}[영광의화살]",at.site);
            CalcDamage.CalcActiveSkillDamage(at, df, 1300);
            
            at.isSkillUsed = true;

            if (UsingLog.usingLog == true)
                Console.WriteLine("- {0}[영광의 화살] 통솔부대 모든 피해 20% 증가 3초 지속", at.site);
            actionAmount0 = 20;
            actionCount0 = 3;
        }


        public override void Passive1Before(CommanderBase at, CommanderBase df)
        {
            actionAmount1 = 5;
            if (df.armyType == CommanderBase.ArmyType.Infantry)
            {
                if (at.armyType == CommanderBase.ArmyType.Archer)
                    at.tempDamageIncrease += actionAmount1;
                else if (at.armyType == CommanderBase.ArmyType.Mixed)
                    at.tempDamageIncrease += (actionAmount1 / 3);
            }
            if (df.armyType == CommanderBase.ArmyType.Cavalry)
            {
                if (at.armyType == CommanderBase.ArmyType.Archer)
                    at.tempDamageDecrease -= actionAmount1;
                else if (at.armyType == CommanderBase.ArmyType.Mixed)
                    at.tempDamageDecrease -= (actionAmount1 / 3);
            }
                
        }
        public override void Passive1After(CommanderBase at, CommanderBase df)
        {
            // 궁병공 40증가. 보병에게 피해 5퍼증가 기마병에게 받는피해 5퍼증가
        }

        public override void Passive2Before(CommanderBase at, CommanderBase df)
        {
            if (at.battleState == CommanderBase.BattleState.Garrison)
            {
                actionAmount2 = 20;
                at.tempDefence += actionAmount2;
            }
        }
        public override void Passive2After(CommanderBase at, CommanderBase df)
        {
            // 주둔시 궁병방어력 20증가 매회공격시 10퍼확률로 상대 공격력증가 무력화. 10초에 한번발동
            if (at.battleState == CommanderBase.BattleState.Garrison)
            {
                Random random = new Random();
                if (df.normalAttackDamage > 0 && random.Next(0, 10) == 0 && actionCount2 <= 0)
                {
                    //하랄스택초기화 어떻게할지..
                    if (UsingLog.usingLog == true)
                        Console.WriteLine("- {0}[타세티의 인내] 상대 지속성 공격력 증가 효과 해제", at.site);
                    actionCount2 = 10;
                }
                actionCount2--;
            }
        }

        public override void Passive3Before(CommanderBase at, CommanderBase df)
        {
        }
        public override void Passive3After(CommanderBase at, CommanderBase df)
        {
            // 스킬피해 입으면 800계수 피해. 주둔사령일때 50퍼 확률로 500피해 20퍼확률로 400피해 10초에 한번발동
            if (at.skillDamage > 0 && actionCount3 <= 0)
            {
                if (UsingLog.usingLog == true)
                    Console.Write("- {0}[격노의 여왕]", at.site);
                CalcDamage.CalcActiveSkillDamage(at, df, 800);

                if (at.battleState == CommanderBase.BattleState.Garrison)
                {
                    Random random = new Random();
                    if (random.Next(0, 2) == 0)
                    {
                        if (UsingLog.usingLog == true)
                            Console.Write("- {0}[격노의 여왕]", at.site);
                        CalcDamage.CalcActiveSkillDamage(at, df, 500);
                    }
                    if (random.Next(0, 5) == 0)
                    {
                        if (UsingLog.usingLog == true)
                            Console.Write("- {0}[격노의 여왕]", at.site);
                        CalcDamage.CalcActiveSkillDamage(at, df, 400);
                    }
                }
                actionCount3 = 10;
            }
            actionCount3--;
        }

        public override void NewBefore(CommanderBase at, CommanderBase df)
        {
            at.silenceTurn = 0;
        }
        public override void NewAfter(CommanderBase at, CommanderBase df)
        {
            // 침묵에 면역. 액티브스킬시전시 대상분노 100감소 2초지속 10초에 한번발동
            if (at.isSkillUsed == true && actionCountNew <= 0)
            {
                if (UsingLog.usingLog == true)
                    Console.WriteLine("- {0}[누비아의 의지] 대상 부대의 분노 100 감소 2초 지속", at.site);
                actionAmountNew = 100;
                df.rageMinus += actionAmountNew;
                AddAfterSkillBonus(at, 0, 1, NewBonus);
                actionCountNew = 10;
            }
            actionCountNew--;
        }
        public void NewBonus(CommanderBase at, CommanderBase df)
        {
            df.rageMinus += actionAmountNew;
        }
    }
}
