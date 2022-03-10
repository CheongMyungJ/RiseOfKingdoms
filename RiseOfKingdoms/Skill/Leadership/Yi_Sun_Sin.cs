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
    internal class Yi_Sun_Sin : SkillBase
    {
        public override void ActiveBefore(CommanderBase at, CommanderBase df)
        {
            df.tempSpeedIncrease -= actionAmount0;

            actionCount0--;
            if (actionCount0 == 0)
                actionAmount0 = 0;
        }

        double extraDamage;
        public override void Active(CommanderBase at, CommanderBase df)
        {
            // 필드에서 계수 2000, 주둔시 1400계수. 대상행속 30퍼감소 3초지속
            if (at.battleState != CommanderBase.BattleState.Garrison)
                extraDamage = CalcDamage.CalcActiveSkillDamage(at, df, 2000);
            else
                extraDamage = CalcDamage.CalcActiveSkillDamage(at, df, 1400);
            if (UsingLog.usingLog == true)
                Console.WriteLine("@스킬시전 {0}", extraDamage);
            at.isSkillUsed = true;

            actionAmount0 = 30;
            actionCount0 = 3;
        }


        public override void Passive1Before(CommanderBase at, CommanderBase df)
        {
            at.tempDefence += (actionAmount1 * 4);
            at.tempDamageIncrease += (actionAmount1 * 3);
        }
        public override void Passive1After(CommanderBase at, CommanderBase df)
        {
            // 연맹영토내 혹은 거점주둔시 일반공격시 10퍼확률로 방어력 20증가. 모든피해 15퍼증가 3초지속
            if (at.battleState == CommanderBase.BattleState.Garrison)
            {
                if (actionCount1 == 0)
                    actionAmount1 = 0;

                Random random = new Random();
                if (df.normalAttackDamage > 0 && random.Next(0, 10) == 0 && actionCount1 <= 0)
                {
                    actionAmount1 = 5;
                    actionCount1 = 3;
                }
                actionCount1--;
            }
        }

        public override void Passive2Before(CommanderBase at, CommanderBase df)
        {
            at.tempDamageIncrease += actionAmount2;
        }
        public override void Passive2After(CommanderBase at, CommanderBase df)
        {
            // 통솔부대 방어력 30퍼 증가. 부대 50퍼 미만이면 피증 20퍼
            if (at.troop * 2 <= at.maxTroop)
            {
                actionAmount2 = 20;
            }
        }

        double actionAmount3_2 = 0;
        public override void Passive3Before(CommanderBase at, CommanderBase df)
        {
            if (at.battleState == CommanderBase.BattleState.Garrison)
            {
                actionAmount3 = 20;
                at.tempAttack += actionAmount3;
            }
            at.tempCounterDamageIncrease += actionAmount3_2;
            // 방패 추가해야함.
        }
        public override void Passive3After(CommanderBase at, CommanderBase df)
        {
            // 거점주둔시 공 20증가. 공격당할시 10퍼확률로 500방패, 반격피해 30퍼증가 3초지속
            if (at.battleState == CommanderBase.BattleState.Garrison)
            {
                if (actionCount3 == 0)
                    actionAmount3_2 = 0;

                Random random = new Random();
                if (at.normalAttackDamage > 0 && random.Next(0, 10) == 0)
                {
                    actionAmount3_2 = 30;
                    actionCount3 = 3;
                }
                actionCount3--;
            }   
        }

        public override void NewBefore(CommanderBase at, CommanderBase df)
        {
            if (at.armyType == CommanderBase.ArmyType.Mixed)
            {
                actionAmountNew = 20;
                at.tempAttack += actionAmountNew;
                at.tempDefence += actionAmountNew;
            }
        }
        public override void NewAfter(CommanderBase at, CommanderBase df)
        {
            // 2병종이상일때 공20 방20 증가
        }
    }
}
