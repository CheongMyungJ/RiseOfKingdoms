using RiseOfKingdoms.Commander;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RiseOfKingdoms.Common.MethodBase;

namespace RiseOfKingdoms.Calculate
{
    internal static class CalcAttack
    {
        public static void CalcActiveSkill(CommanderBase at, CommanderBase df)
        {
            if (at.rage >= at.maxRage)
            {
                at.active_skill_queue.Enqueue(at.active_skill[0]);
                at.active_skill_queue.Enqueue(new DelegateMethod(Skill.SkillBase.Dummy));
                if (at.active_skill.Count > 1) // 부사령관 존재하면
                {
                    at.active_skill_queue.Enqueue(at.active_skill[1]);
                    at.active_skill_queue.Enqueue(new DelegateMethod(Skill.SkillBase.Dummy));
                }
                at.rage = 0;
            }

            if (at.active_skill_queue.Count > 0)
            {
                DelegateMethod method = at.active_skill_queue.Peek();
                if (method != Skill.SkillBase.Dummy && at.silenceTurn > 0)
                {
                    // 침묵상태 아무것도 하지 않음.
                }
                else
                {
                    method = at.active_skill_queue.Dequeue();
                    method(at, df);
                }   
            }

            if (at.active_skill_bonus_list.Count > 0)
            {
                foreach (DelegateMethod method in at.active_skill_bonus_list[0])
                {
                    method(at, df);
                }
                at.active_skill_bonus_list.RemoveAt(0);
            }
        }
        public static void CalcNormalAttack(CommanderBase at, CommanderBase df)
        {
            if (at.forbiddenTurn <= 0)
                CalcDamage.CalcNormalDamage(at, df);// 금수상태 일반공격 하지않음.
        }
        public static void CalcCounterAttack(CommanderBase at, CommanderBase df)
        {
            CalcDamage.CalcCounterDamage(at, df);
        }
    }
}
