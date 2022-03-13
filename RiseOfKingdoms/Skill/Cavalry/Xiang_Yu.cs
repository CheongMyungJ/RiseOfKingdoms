using RiseOfKingdoms.Commander;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiseOfKingdoms.Calculate;
using static RiseOfKingdoms.Commander.CommanderBase;
using RiseOfKingdoms.Common;

namespace RiseOfKingdoms.Skill
{
    internal class Xiang_Yu : SkillBase
    {
        public override void Init(CommanderBase bs, bool isFirst, int cnt)
        {
            base.Init(bs, isFirst);
            if (isFirst == true)
                bs.maxRage -= 150;
            else
                bs.maxRage -= 50;
        }

        bool togle = true;
        public override void Active(CommanderBase at, CommanderBase df)
        {
            // 1700 계수 스킬
            if (UsingLog.usingLog == true)
                Console.Write("- {0}[패왕의 용기]", at.site);
            CalcDamage.CalcActiveSkillDamage(at, df, 1700);
            
            at.isSkillUsed = true;
            togle = !togle;

            if (UsingLog.usingLog == true)
                Console.WriteLine("- {0}[패왕의 용기] 대상 부대 방어력 30% 감소. 3초 지속", at.site);
            // 방깍 3초
            AddBeforeSkillBonus(at, 3, ActiveBonusStart, ActiveBonusEnd);
        }

        public void ActiveBonusStart(CommanderBase at, CommanderBase df)
        {
            if (df.activeDefence_dbf < 30)
            {
                df.activeDefence_dbf = 30;
            }
        }

        public void ActiveBonusEnd(CommanderBase at, CommanderBase df)
        {
            if (df.activeDefence_dbf == 30)
            {
                df.activeDefence_dbf = 0;
            }
        }

        public override void Passive1Before(CommanderBase at, CommanderBase df)
        {
        }
        public override void Passive1After(CommanderBase at, CommanderBase df)
        {
            // 기병공 40 증가
        }

        public override void Passive2Before(CommanderBase at, CommanderBase df)
        {
            if (at.battleState == BattleState.Conquering)
            {
                actionAmount2 = 5;
            }
            at.tempDamageIncrease += actionAmount2;
        }
        public override void Passive2After(CommanderBase at, CommanderBase df)
        {
            if (at.battleState == BattleState.Conquering)
            {
                // 공성시 데미지 5퍼증가, 10퍼확률 400계수 딜. 3초에 한번 발동
                Random random = new Random();
                if (random.Next(0, 10) == 0 && actionCount2 <= 0)
                {
                    if (UsingLog.usingLog == true)
                        Console.Write("- {0}[천하난무]", at.site);
                    CalcDamage.CalcActiveSkillDamage(at, df, 400);
                    actionCount2 = 3;
                }
                actionCount2--;
            }   
        }

        bool togle2 = true;
        public override void Passive3Before(CommanderBase at, CommanderBase df)
        {
            at.tempDamageIncrease += actionAmount3;
        }
        public override void Passive3After(CommanderBase at, CommanderBase df)
        {
            if (actionCount3 == 0)
                actionAmount3 = 0;

            // 분노 50 감소, 스킬시전시 기병 데미지 5퍼 증가 10초지속 6회 중복
            if (togle != togle2)
            {
                togle2 = togle;
                
                if (at.armyType == ArmyType.Cavalry)
                {
                    actionAmount3 += 5;
                    actionAmount3 = Math.Min(30, actionAmount3);
                }
                else if (at.armyType == ArmyType.Mixed)
                {
                    actionAmount3 += (5 / 3);
                    actionAmount3 = Math.Min(10, actionAmount3);
                }
                if (UsingLog.usingLog == true)
                    Console.WriteLine("- {0}[쾌전상승] 기마병 피해 {1}% 증가", at.site, actionAmount3);

                actionCount3 = 10;
            }

            actionCount3--;
        }

        public override void NewBefore(CommanderBase at, CommanderBase df)
        {
        }
        public override void NewAfter(CommanderBase at, CommanderBase df)
        {
            // 스킬데미지 10퍼 증가. 2턴이상 분노획득시 스킬데미지 10퍼 증가 3초. 5초에 한번 발동
        }
    }
}
