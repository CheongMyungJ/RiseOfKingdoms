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
    internal class Bertrand_du_Guesclin : SkillBase
    {
        
        double extraDamage;
        public override void Active(CommanderBase at, CommanderBase df)
        {
            // 다음 3초간 일반공격시 100퍼확률로 고정피해 700계수, 분노 20깍
            AddAfterSkillBonus(at, 1, 3, ActiveBonus);
            actionAmount0 = 20;
            df.rageMinus += actionAmount0;
            at.isSkillUsed = true;
        }
        public void ActiveBonus(CommanderBase at, CommanderBase df)
        {
            extraDamage = CalcDamage.CalcActiveSkillDamage(at, df, 700);
            if (UsingLog.usingLog == true)
                Console.WriteLine("@추가스킬시전 {0}", extraDamage);
        }

        public override void Passive1Before(CommanderBase at, CommanderBase df)
        {
            if (at.battleState != CommanderBase.BattleState.Garrison)
            {
                actionAmount1 = 5;
                at.tempSpeedIncrease += (actionAmount1 * 2);
                at.tempDamageDecrease += actionAmount1;
            }
        }
        public override void Passive1After(CommanderBase at, CommanderBase df)
        {
            // 기마병 공격력10, 생명력10증가. 연맹영토밖에서 기마병 행속 10, 피감5
        }

        public override void Passive2Before(CommanderBase at, CommanderBase df)
        {
            if (at.battleState == CommanderBase.BattleState.Conquering)
            {
                actionAmount2 = 10;
                at.tempDamageIncrease += actionAmount2;
                at.tempDamageIncrease += actionAmount2_2;
            }
        }
        double actionAmount2_2 = 0;
        new int actionCount2 = 10;
        public override void Passive2After(CommanderBase at, CommanderBase df)
        {
            // 거점공격시 피증 10. 10초마다 기마병피해 1퍼증가 15초지속 5회중첩
            if (at.battleState == CommanderBase.BattleState.Conquering)
            {
                if (actionCount2 == 10)
                {
                    if (at.armyType == CommanderBase.ArmyType.Cavalry)
                    {
                        actionAmount2_2 += 1;
                        actionAmount2_2 = Math.Min(5, actionAmount2_2);
                    }
                    else if (at.armyType == CommanderBase.ArmyType.Mixed)
                    {
                        actionAmount2_2 += (1/3);
                        actionAmount2_2 = Math.Min(5/3, actionAmount2_2);
                    }
                    actionCount2 = 0;
                }
                actionCount2++;
            }
        }

        public override void Passive3Before(CommanderBase at, CommanderBase df)
        {
        }
        public override void Passive3After(CommanderBase at, CommanderBase df)
        {
            // 기마방 20, 공격받을때 10퍼확률로 치료효과(250계수) 3초지속 5초에한번발동

            Random random = new Random();
            if (at.normalAttackDamage > 0 && random.Next(0, 10) == 0 && actionCount3 <= 0)
            {
                actionAmount3 = 250;
                CalcDamage.CalcHealingEffect(at, df, actionAmount3);
                AddAfterSkillBonus(at, 0, 2, PassiveBonus);
                actionCount3 = 5;
            }
            actionCount3--;

        }
        public void PassiveBonus(CommanderBase at, CommanderBase df)
        {
            CalcDamage.CalcHealingEffect(at, df, actionAmount3);
        }

        public override void NewBefore(CommanderBase at, CommanderBase df)
        {
        }
        public override void NewAfter(CommanderBase at, CommanderBase df)
        {
            // 스피감 5퍼, 스킬피해받을때 대상부대에게 스킬피해 400계수. 5초에한번발동
            if (at.skillDamage > 0 && actionCountNew <= 0)
            {
                CalcDamage.CalcActiveSkillDamage(at, df, 400);
                actionCountNew = 5;
            }
            actionCountNew--;
        }

    }
}
