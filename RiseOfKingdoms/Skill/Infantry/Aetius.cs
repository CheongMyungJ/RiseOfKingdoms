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
    internal class Aetius : SkillBase
    {
        public override void Active(CommanderBase at, CommanderBase df)
        {
            // 계수 2300 상대 피 50퍼 미만이면 3초간 지속피해 150씩
            if (UsingLog.usingLog == true)
                Console.Write("- {0}[제국의 창]", at.site);
            CalcDamage.CalcActiveSkillDamage(at, df, 2300);
            at.isSkillUsed = true;
            if (df.troop * 2 <= df.maxTroop)
            {
                actionAmount0 = CalcDamage.CalcActiveSkillDamage(at, df, 150, false);
                AddAfterSkillBonus(at, 1, 3, ActiveBonus);
            }
            
        }
        public void ActiveBonus(CommanderBase at, CommanderBase df)
        {
            if (UsingLog.usingLog == true)
                Console.Write("- {0}[제국의 창]", at.site);
            CalcDamage.CalcAdditionalSkillDamage(df, actionAmount0);
        }

        public override void Passive1Before(CommanderBase at, CommanderBase df)
        {
            if (at.battleState == CommanderBase.BattleState.Garrison)
            {
                if (at.armyType == CommanderBase.ArmyType.Infantry)
                    actionAmount1 = 15;
                else if (at.armyType == CommanderBase.ArmyType.Mixed)
                    actionAmount1 = 5;
                else
                    actionAmount1 = 0;
                at.tempDefence += actionAmount1;
                at.tempHealth += actionAmount1;
            }
        }
        public override void Passive1After(CommanderBase at, CommanderBase df)
        {
            // 보병 공15, 주둔상태일때 보병방생 15증가
        }

        public override void Passive2Before(CommanderBase at, CommanderBase df)
        {
            if (at.armyType == CommanderBase.ArmyType.Infantry)
            {
                df.tempDamageDecrease -= actionAmount2;
            }
            else if (at.armyType == CommanderBase.ArmyType.Mixed)
            {
                df.tempDamageDecrease -= (actionAmount2 / 3);
            }
        }
        public override void Passive2After(CommanderBase at, CommanderBase df)
        {
            // 반격피해 20증가. 주둔시 대상부대에 디버프 보병한테받는피해증가 15초지속 10회중첩 10초에한번발동
            if (actionCount2 == 0)
                actionAmount2 = 0;

            if (at.battleState == CommanderBase.BattleState.Garrison && df.normalAttackDamage > 0 && actionCount2 <= 5)
            {
                actionAmount2++;
                actionAmount2 = Math.Min(10, actionAmount2);
                if (UsingLog.usingLog == true)
                    Console.WriteLine("- {0}[갈리아 방어선] 대상에게 보병에게 받는 피해 {1}%증가 디버프 발동", at.site, actionAmount2);
                actionCount2 = 15;
            }
            actionCount2--;
        }

        public override void Passive3Before(CommanderBase at, CommanderBase df)
        {
        }
        public override void Passive3After(CommanderBase at, CommanderBase df)
        {
            // 모든피해 10퍼증가. 지속추가피해받는 대상에게 일반공격시 2초침묵 7초에한번발동
            if (df.additionalSkillDamage > 0 && df.normalAttackDamage > 0 && actionCount3 <= 0)
            {
                if (UsingLog.usingLog == true)
                    Console.WriteLine("- {0}[카탈라우눔 전투] 대상 부대 2초간 침묵", at.site);
                AddAfterSkillBonus(at, 0, 1, Passive3Bonus);
                actionCount3 = 7;
            }
            actionCount3--;
        }
        public void Passive3Bonus(CommanderBase at, CommanderBase df)
        {
            if (df.silenceTurn <= 1)
                df.silenceTurn = 3; 
        }

        public override void NewBefore(CommanderBase at, CommanderBase df)
        {
        }
        public override void NewAfter(CommanderBase at, CommanderBase df)
        {
            //일반피해 10퍼감소. 스킬시전시 30퍼확률로 디버프 2회. 10초에 한번발동
            Random random = new Random();
            if (at.isSkillUsed == true && random.Next(0, 10) < 3 && actionCountNew <= 0)
            {
                actionAmount2 += 2;
                actionAmount2 = Math.Min(10, actionAmount2);
                if (UsingLog.usingLog == true)
                    Console.WriteLine("- {0}[니벨룽의 노래] 대상에게 보병에게 받는 피해 {1}%증가 디버프 발동", at.site, actionAmount2);
                actionCountNew = 10;
            }
            actionCountNew--;
        }
    }
}
