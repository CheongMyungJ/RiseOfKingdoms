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
    internal class Alexander_Nevsky : SkillBase
    {
        
        double extraDamage;
        public override void Active(CommanderBase at, CommanderBase df)
        {
            // 2300 계수 스킬
            extraDamage = CalcDamage.CalcActiveSkillDamage(at, df, 2300);
            if (UsingLog.usingLog == true)
                Console.WriteLine("@스킬시전 {0}", extraDamage);
            at.isSkillUsed = true;
        }


        public override void Passive1Before(CommanderBase at, CommanderBase df)
        {
            if (at.armyType == CommanderBase.ArmyType.Cavalry)
                actionAmount1 = 20;
            at.tempHealth += actionAmount1;
        }
        public override void Passive1After(CommanderBase at, CommanderBase df)
        {
            // 기병공 20증가, 연맹영토 밖에서 기병생 20 증가.
        }
        
        public override void Passive2Before(CommanderBase at, CommanderBase df)
        {
        }
        public override void Passive2After(CommanderBase at, CommanderBase df)
        {
            // 기병방 20증가, 대상이 협공일시 모든피해 10증가. 받는 모든피해 5감소.
        }

        double actionAmount3_2 = 0;
        public override void Passive3Before(CommanderBase at, CommanderBase df)
        {
            if (at.armyType == CommanderBase.ArmyType.Cavalry)
            {
                actionAmount3 = 25;
            }
            at.tempSkillDamageIncrease += actionAmount3;
            at.tempSkillDamageIncrease += actionAmount3_2;

        }
        public override void Passive3After(CommanderBase at, CommanderBase df)
        {
            if (at.armyType == CommanderBase.ArmyType.Cavalry)
            {
                // 기마병이면 스킬피해 25증가. 스킬시전후 스킬피해 35증가. 4초지속 5초에 한번 발동
                if (actionCount3 == 1)
                    actionAmount3_2 = 0;

                if (at.isSkillUsed && actionCount3 <= 0)
                {
                    actionAmount3_2 = 35;
                    actionCount3 = 5;
                }
                actionCount3--;
            }   
        }

        public override void NewBefore(CommanderBase at, CommanderBase df)
        {
            at.tempHealth += actionAmountNew;
        }
        public override void NewAfter(CommanderBase at, CommanderBase df)
        {
            // 일반피해 5퍼증가. 공격받을때 10퍼 확률로 기마생명 30증가. 3초지속 5초에 한번 발동
            if (actionCountNew == 2)
                actionAmountNew = 0;

            Random random = new Random();
            if (at.normalAttackDamage > 0 && random.Next(0, 10) == 0 && actionCountNew <= 0)
            {
                if (at.armyType == CommanderBase.ArmyType.Cavalry)
                    actionAmountNew = 30;
                actionCountNew = 5;
            }
            actionCountNew--;
        }
    }
}
