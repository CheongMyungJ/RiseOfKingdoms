using RiseOfKingdoms.Calculate;
using RiseOfKingdoms.Commander;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RiseOfKingdoms.Common.MethodBase;

namespace RiseOfKingdoms.Common
{
    internal class Main
    {
        public static (bool, double) Run(CommanderBase at, CommanderBase df, bool isRepeat)
        {
            int turn = 1;
            while (at.troop > 0 && df.troop > 0)
            {
                if (isRepeat == false)
                    Console.WriteLine(" {0}번째 턴========================================================", turn++);
                

                BeforeAction(at, df);

                //일반공격
                CalcAttack.CalcNormalAttack(at, df);
                CalcAttack.CalcCounterAttack(df, at);
                CalcAttack.CalcNormalAttack(df, at);
                CalcAttack.CalcCounterAttack(at, df);
                //스킬
                CalcAttack.CalcActiveSkill(at, df);
                CalcAttack.CalcActiveSkill(df, at);

                AfterAction(at, df);

                if (isRepeat == false)
                {
                    Console.WriteLine("@공격측 남은 부대수 : {0}", at.troop);
                    Console.WriteLine("@수비측 남은 부대수 : {0}", df.troop);
                }
            }
            if (at.troop <= 0 && df.troop <= 0)
            {
                if (isRepeat == false)
                {
                    Console.WriteLine("무승부!");
                }
                return (true, 0);
            }
            else if (at.troop <= 0)
            {
                if (isRepeat == false)
                {
                    Console.WriteLine("수비측 승리. 남은 부대수 : {0}", df.troop);
                }
                return (false, df.troop);
            }
            else
            {
                if (isRepeat == false)
                {
                    Console.WriteLine("공격측 승리. 남은 부대수 : {0}", at.troop);
                }
                return (true, at.troop);
            }
        }
        public static void BeforeAction(CommanderBase at, CommanderBase df)
        {
            foreach (DelegateMethod method in at.before_skill)
            {
                method(at, df);
            }
            foreach (DelegateMethod method in df.before_skill)
            {
                method(df, at);
            }

            if (at.before_skill_bonus_list.Count > 0)
            {
                foreach (DelegateMethod method in at.before_skill_bonus_list[0])
                {
                    method(at, df);
                }
                at.before_skill_bonus_list.RemoveAt(0);
            }

            if (df.before_skill_bonus_list.Count > 0)
            {
                foreach (DelegateMethod method in df.before_skill_bonus_list[0])
                {
                    method(df, at);
                }
                df.before_skill_bonus_list.RemoveAt(0);
            }
        }


        public static void AfterAction(CommanderBase at, CommanderBase df)
        {
            foreach (DelegateMethod method in at.after_skill)
            {
                method(at, df);
            }
            foreach (DelegateMethod method in df.after_skill)
            {
                method(df, at);
            }

            // 추가분노 처리
            if (at.normalAttackDamage > df.normalAttackDamage)
                at.ragePlus += 10;
            else if (at.normalAttackDamage < df.normalAttackDamage)
                df.ragePlus += 10;
            if (at.counterAttackDamage > df.counterAttackDamage)
                at.ragePlus += 10;
            else if (at.counterAttackDamage < df.counterAttackDamage)
                df.ragePlus += 10;

            // 공격측 데미지 처리
            if (at.shield >= at.normalAttackDamage + at.counterAttackDamage + at.skillDamage)
            {
                at.shield -= at.normalAttackDamage + at.counterAttackDamage + at.skillDamage + at.additionalSkillDamage;
                at.troop = at.troop + Math.Round(at.heal);
            }
            else
            {
                at.troop = at.troop - Math.Round(at.normalAttackDamage) - Math.Round(at.counterAttackDamage) - Math.Round(at.skillDamage) - Math.Round(at.additionalSkillDamage) + Math.Round(at.shield) + Math.Round(at.heal);
                at.shield = 0;
            }
            // 공격측 분노 처리
            at.rage = at.rage + Math.Min(at.ragePlus, 220) - at.rageMinus;

            // 수비측 데미지 처리
            if (df.shield >= df.normalAttackDamage + df.counterAttackDamage + df.skillDamage)
            {
                df.shield -= df.normalAttackDamage + df.counterAttackDamage + df.skillDamage + at.additionalSkillDamage;
                df.troop = df.troop + Math.Round(df.heal);
            }
            else
            {
                df.troop = df.troop - Math.Round(df.normalAttackDamage) - Math.Round(df.counterAttackDamage) - Math.Round(df.skillDamage) - Math.Round(df.additionalSkillDamage) + Math.Round(df.shield) + Math.Round(df.heal);
                df.shield = 0;
            }
            // 수비측 분노 처리
            df.rage = df.rage + Math.Min(df.ragePlus, 220) - df.rageMinus;

            at.Final();
            df.Final();
        }

        public static void RepeatRun(CommanderBase at, CommanderBase df, int cnt)
        {
            double drawCount = 0;
            double atWinCount = 0;
            double dfWinCount = 0;
            
            double atLeftTroop = 0;
            double dfLeftTroop = 0;

            for (int i = 0; i < cnt; i++)
            {
                var result = Run(at, df, true);
                if (result.Item1 == true && result.Item2 == 0)
                {
                    drawCount++;
                }
                else if (result.Item1 == true)
                {
                    atWinCount++;
                    atLeftTroop += result.Item2;
                }
                else
                {
                    dfWinCount++;
                    dfLeftTroop += result.Item2;
                }
                at.Reset();
                df.Reset();
                Console.Write("분석중 {0}%\r", Math.Round(((double)i / cnt) * 100d, 2));
            }
            Console.WriteLine("무승부 확률 : {0}%", Math.Round((drawCount / (drawCount  + atWinCount + dfWinCount)) * 100, 2));
            Console.WriteLine("공격측 승리 확률 : {0}%, 남은 부대수 평균 : {1}", Math.Round((atWinCount/(drawCount + atWinCount + dfWinCount)) * 100, 2), Math.Round(atLeftTroop / atWinCount));
            Console.WriteLine("수비측 승리 확률 : {0}, 남은 부대수 평균 : {1}", Math.Round((dfWinCount / (drawCount + atWinCount + dfWinCount)) * 100, 2), Math.Round(dfLeftTroop / dfWinCount));
        }

    }
}
