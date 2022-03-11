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
    internal class Minamoto_no_Yoshitsune : SkillBase
    {
        
        double extraDamage;
        public override void Active(CommanderBase at, CommanderBase df)
        {
            // 1400계수. 75퍼확률로 추가피해 600계수 2초간
            if (UsingLog.usingLog == true)
                Console.Write("- {0}[경팔류]", at.site);
            extraDamage = CalcDamage.CalcActiveSkillDamage(at, df, 1400);
            Random random = new Random();
            if (random.Next(0, 4) < 3)
            {
                extraDamage = CalcDamage.CalcActiveSkillDamage(at, df, 600, false);
                AddAfterSkillBonus(at, 1, 2, ActiveBonus);
            }
            at.isSkillUsed = true;
        }
        public void ActiveBonus(CommanderBase at, CommanderBase df)
        {
            if (UsingLog.usingLog == true)
                Console.Write("- {0}[경팔류]", at.site);
            CalcDamage.CalcAdditionalSkillDamage(df, extraDamage);
        }

        public override void Passive1Before(CommanderBase at, CommanderBase df)
        {
        }
        public override void Passive1After(CommanderBase at, CommanderBase df)
        {
            // 기마공 20퍼, 행속 10퍼
        }

        public override void Passive2Before(CommanderBase at, CommanderBase df)
        {
        }
        public override void Passive2After(CommanderBase at, CommanderBase df)
        {
            // 야만인피해 50퍼
        }

        public override void Passive3Before(CommanderBase at, CommanderBase df)
        {
            df.tempDamageDecrease -= actionAmount3;

        }
        public override void Passive3After(CommanderBase at, CommanderBase df)
        {
            // 일반공격시 10퍼확률로 3초간 대상부대 받는피해 30퍼증가. 5초에한번발동
            if (actionCount3 == 2)
                actionAmount3 = 0;

            Random random = new Random();
            if (df.normalAttackDamage > 0 && random.Next(0, 10) == 0 && actionCount3 <= 0)
            {
                if (UsingLog.usingLog == true)
                    Console.WriteLine("- {0}[명장] 대상 부대 받는피해 30% 증가. 3초 지속", at.site);
                actionAmount3 = 30;
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
