using RiseOfKingdoms.Commander;
using RiseOfKingdoms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseOfKingdoms.Skill
{
    internal class SkillBase : MethodBase
    {
        public override void Init(CommanderBase bs, bool isFirst = true, int cnt = 0)
        {
            DelegateMethod Passive1Before = new DelegateMethod(this.Passive1Before);
            DelegateMethod Passive2Before = new DelegateMethod(this.Passive2Before);
            DelegateMethod Passive3Before = new DelegateMethod(this.Passive3Before);
            DelegateMethod NewBefore = new DelegateMethod(this.NewBefore);
            DelegateMethod ActiveBefore = new DelegateMethod(this.ActiveBefore);
            DelegateMethod Active = new DelegateMethod(this.Active);
            DelegateMethod Passive1After = new DelegateMethod(this.Passive1After);
            DelegateMethod Passive2After = new DelegateMethod(this.Passive2After);
            DelegateMethod Passive3After = new DelegateMethod(this.Passive3After);
            DelegateMethod NewAfter = new DelegateMethod(this.NewAfter);
            bs.before_skill.Add(Passive1Before);
            bs.before_skill.Add(Passive2Before);
            bs.before_skill.Add(Passive3Before);
            bs.before_skill.Add(NewBefore);
            bs.before_skill.Add(ActiveBefore);
            bs.active_skill.Add(Active);
            bs.after_skill.Add(Passive1After);
            bs.after_skill.Add(Passive2After);
            bs.after_skill.Add(Passive3After);
            bs.after_skill.Add(NewAfter);
        }

        public virtual void ActiveBefore(CommanderBase at, CommanderBase df) { }
        protected int actionCount0 = 0;
        protected double actionAmount0 = 0;
        public virtual void Active(CommanderBase at, CommanderBase df) { }

        protected int actionCount1 = 0;
        protected double actionAmount1 = 0;
        public virtual void Passive1Before(CommanderBase at, CommanderBase df) { }
        public virtual void Passive1After(CommanderBase at, CommanderBase df) { }

        protected int actionCount2 = 0;
        protected double actionAmount2 = 0;
        public virtual void Passive2Before(CommanderBase at, CommanderBase df) { }
        public virtual void Passive2After(CommanderBase at, CommanderBase df) { }

        protected int actionCount3 = 0;
        protected double actionAmount3 = 0;
        public virtual void Passive3Before(CommanderBase at, CommanderBase df) { }
        public virtual void Passive3After(CommanderBase at, CommanderBase df) { }

        protected int actionCountNew = 0;
        protected double actionAmountNew = 0;
        public virtual void NewBefore(CommanderBase at, CommanderBase df) { }
        public virtual void NewAfter(CommanderBase at, CommanderBase df) { }
    }
}
