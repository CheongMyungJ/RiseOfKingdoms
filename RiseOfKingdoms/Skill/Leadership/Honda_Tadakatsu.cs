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
    internal class Honda_Tadakatsu : SkillBase
    {
        bool isFirst = true;
        public override void Init(CommanderBase bs, bool isFirst, int cnt)
        {
            base.Init(bs, isFirst);
            this.isFirst = isFirst;
            actionCountNew = 57;
        }
        public override void ActiveBefore(CommanderBase at, CommanderBase df)
        {
        }

        public override void Active(CommanderBase at, CommanderBase df)
        {
            // 주사령관이면 2500, 부사령관이면 1250 딜
            if (UsingLog.usingLog == true)
                Console.Write("- {0}[톤보키리]", at.site);
            if (isFirst == true)
                CalcDamage.CalcActiveSkillDamage(at, df, 2500);
            else
                CalcDamage.CalcActiveSkillDamage(at, df, 1250);
            at.isSkillUsed = true;
        }


        public override void Passive1Before(CommanderBase at, CommanderBase df)
        {
            at.tempAttack += actionAmount1;
        }
        public override void Passive1After(CommanderBase at, CommanderBase df)
        {
            // 공격력 10퍼 증가. 행속 20퍼 증가. 공격대상이 부대일경우 공 30퍼 증가
            if (df.battleState == CommanderBase.BattleState.Field || df.battleState == CommanderBase.BattleState.Conquering)
                actionAmount1 = 30;
        }

        double actionAmount2_2 = 0;
        double actionAmount2_3 = 0;
        public override void Passive2Before(CommanderBase at, CommanderBase df)
        {
            actionAmount2 = 5;
            at.tempDamageDecrease += actionAmount2;
            df.tempSpeedIncrease -= actionAmount2_2;
        }
        public override void Passive2After(CommanderBase at, CommanderBase df)
        {
            // 피감 5퍼. 스킬시전후 고정피해 2턴간 (200계수), 적 행속 감소 50퍼 2턴간. 5초에한번발동
            if (actionCount2 == 3)
                actionAmount2_2 = 0;

            if (at.isSkillUsed == true && actionCount2 <= 0)
            {
                if (UsingLog.usingLog == true)
                    Console.Write("- {0}[화실겸비]", at.site);
                actionAmount2_3 = CalcDamage.CalcActiveSkillDamage(at, df, 200, false);
                AddAfterSkillBonus(at, 0, 2, Passive2Bonus);
                actionAmount2_2 = 50;
                actionCount2 = 5;
            }
            actionCount2--;
        }
        public void Passive2Bonus(CommanderBase at, CommanderBase df)
        {
            if (UsingLog.usingLog == true)
                Console.Write("- {0}[화실 겸비]", at.site);
            CalcDamage.CalcAdditionalSkillDamage(df, actionAmount2_3);
        }


        public override void Passive3Before(CommanderBase at, CommanderBase df)
        {
            at.tempSkillDamageIncrease += actionAmount3;

        }
        public override void Passive3After(CommanderBase at, CommanderBase df)
        {
            int factor;
            // 부대인원 10퍼증가. 병력 8퍼감소마다(2병종이면 5퍼감소마다) 스킬피해 5퍼증가. 최대 60퍼
            if (at.armyType == CommanderBase.ArmyType.Mixed)
                factor = 5;
            else
                factor = 8;

            int troopDecreaseRate = (int)((1 - (at.troop / at.maxTroop)) * 100);
            actionAmount3 = (troopDecreaseRate / factor) * 5;
            actionAmount3 = Math.Min(actionAmount3, 60);
            if (UsingLog.usingLog == true)
                Console.WriteLine("- {0}[도쿠가와 사천왕] 스킬피해 {1}% 증가", at.site, actionAmount3);
        }

        public override void NewBefore(CommanderBase at, CommanderBase df)
        {
        }
        public override void NewAfter(CommanderBase at, CommanderBase df)
        {
            // 필드에서 일반공격피해받으면 해당피해 30퍼감소시킴 최대 57회
            if (at.battleState != CommanderBase.BattleState.Garrison && at.normalAttackDamage > 0 && actionCountNew > 0)
            {
                actionCountNew--;
                if (UsingLog.usingLog == true)
                    Console.WriteLine("- {0}[불패의 역] 데미지 {1} 감소. {2}턴 남음", at.site, Math.Round(at.normalAttackDamage * 0.3), actionCountNew);
                at.normalAttackDamage *= 0.7;
            }
        }
    }
}
