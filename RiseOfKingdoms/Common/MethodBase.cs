using RiseOfKingdoms.Commander;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfKingdoms.Common
{
    internal abstract class MethodBase
    {
        public delegate void DelegateMethod(CommanderBase at, CommanderBase df);
        public static void Dummy(CommanderBase at, CommanderBase df) { }
        public abstract void Init(CommanderBase commander, bool bl = true, int cnt = 0);
        public static void AddBeforeSkillBonus(CommanderBase at, int cnt, DelegateMethod start, DelegateMethod end)
        {
            if (at.before_skill_bonus_list.Count == 0)
                at.before_skill_bonus_list.Add(new List<DelegateMethod>() { start });
            else
                at.before_skill_bonus_list[0].Add(start);


            for (int i = 1; i < cnt; i++)
            {
                if (at.before_skill_bonus_list.Count <= i)
                    at.before_skill_bonus_list.Add(new List<DelegateMethod>() { Dummy });
            }

            if (at.before_skill_bonus_list.Count == cnt)
                at.before_skill_bonus_list.Add(new List<DelegateMethod>() { end });
            else
                at.before_skill_bonus_list[cnt].Add(end);
        }

        public static void AddAfterSkillBonus(CommanderBase at, int dummyCnt, int cnt, DelegateMethod method)
        {
            for (int i = 0; i < dummyCnt + cnt; i++)
            {
                if (at.before_skill_bonus_list.Count <= i)
                    at.before_skill_bonus_list.Add(new List<DelegateMethod>() { (i < dummyCnt ? Dummy : method) });
                else
                    at.before_skill_bonus_list[i].Add((i < dummyCnt ? Dummy : method));
            }
        }
    }
}
