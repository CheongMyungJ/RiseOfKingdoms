﻿using RiseOfKingdoms.Commander;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiseOfKingdoms.Calculate;
using RiseOfKingdoms.Common;

namespace RiseOfKingdoms.Skill
{
    internal class Jadwiga : SkillBase
    {
        public override void ActiveBefore(CommanderBase at, CommanderBase df)
        {
            at.tempDamageIncrease += actionAmount0;

            actionCount0--;
            if (actionCount0 == 0)
                actionAmount0 = 0;
        }

        double extraDamage;
        public override void Active(CommanderBase at, CommanderBase df)
        {
            // 1500계수. 모피증 20퍼증가 3초지속
            extraDamage = CalcDamage.CalcActiveSkillDamage(at, df, 1500);
            if (UsingLog.usingLog == true)
                Console.WriteLine("@스킬시전 {0}", extraDamage);
            at.isSkillUsed = true;

            actionAmount0 = 20;
            actionCount0 = 3;
        }


        public override void Passive1Before(CommanderBase at, CommanderBase df)
        {
            if (at.battleState == CommanderBase.BattleState.Garrison)
            {
                actionAmount1 = 20;
                at.tempDefence += actionAmount1;
                at.tempHealth += actionAmount1;
            }
            else
            {
                actionAmount1 = 5;
                at.tempDefence += (actionAmount1 * 2);
                at.tempSpeedIncrease += (actionAmount1 * 3);
            }
        }
        public override void Passive1After(CommanderBase at, CommanderBase df)
        {
            // 필드에서 방10, 행속15증가. 주둔시 기마방20, 생20증가.
        }

        public override void Passive2Before(CommanderBase at, CommanderBase df)
        {
            if (at.battleState == CommanderBase.BattleState.Garrison)
            {
                actionAmount2 = 5;
                if (df.armyType == CommanderBase.ArmyType.Archer)
                {
                    if (at.armyType == CommanderBase.ArmyType.Cavalry)
                        at.tempDamageIncrease += actionAmount2;
                    else if (at.armyType == CommanderBase.ArmyType.Mixed)
                        at.tempDamageIncrease += (actionAmount2 / 3);
                }
                if (df.armyType == CommanderBase.ArmyType.Infantry)
                {
                    if (at.armyType == CommanderBase.ArmyType.Cavalry)
                        at.tempDamageDecrease -= actionAmount2;
                    else if (at.armyType == CommanderBase.ArmyType.Mixed)
                        at.tempDamageDecrease -= (actionAmount2 / 3);
                }
            }
        }
        public override void Passive2After(CommanderBase at, CommanderBase df)
        {
            // 스피감10퍼, 거점주둔시 기마병이 궁병에게 입히는 피해 5퍼증가. 보병에게 받는피해 5퍼 증가
        }

        public override void Passive3Before(CommanderBase at, CommanderBase df)
        {
        }
        public override void Passive3After(CommanderBase at, CommanderBase df)
        {
            // 스킬피해 10퍼증가, 스킬피해받을시 초당 50분노회복 3초지속. 8초에한번 발동
            if (actionCount3 == 5)
                actionAmount3 = 0;

            if (at.skillDamage > 0 && actionCount3 <= 0)
            {
                actionAmount3 = 50;
                at.ragePlus += actionAmount3;
                AddAfterSkillBonus(at, 0, 2, Passive3Bonus);
                actionCount3 = 8;
            }
            actionCount3--;
        }
        public void Passive3Bonus(CommanderBase at, CommanderBase df)
        {
            at.ragePlus += actionAmount3;
        }

        double actionAmountNew2 = 0;
        public override void NewBefore(CommanderBase at, CommanderBase df)
        {
            if (df.battleState == CommanderBase.BattleState.Conquering)
            {
                actionAmountNew = 10;
                at.tempDamageIncrease += actionAmountNew;
            }
            at.tempDamageDecrease += actionAmountNew2;
        }
        public override void NewAfter(CommanderBase at, CommanderBase df)
        {
            if (actionCountNew == 0)
                actionAmountNew2 = 0;
            // 집결부대에게 입히는 피해 10퍼증가. 스킬시전시 받피감 10퍼 4초지속
            if (at.isSkillUsed == true)
            {
                actionAmountNew2 = 10;
                actionCountNew = 4;
            }
            actionCountNew--;
        }
    }
}
