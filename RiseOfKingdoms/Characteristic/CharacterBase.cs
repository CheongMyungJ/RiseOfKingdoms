using RiseOfKingdoms.Commander;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiseOfKingdoms.Skill;
using RiseOfKingdoms.Common;

namespace RiseOfKingdoms.Characteristic
{
    internal class CharacterBase : MethodBase
    {
        protected int Count = 0;
        public override void Init(CommanderBase at, bool bl = true, int cnt = 0) 
        {
            Count = cnt;
            at.before_skill.Add(new DelegateMethod(BeforeAction));
            at.after_skill.Add(new DelegateMethod(AfterAction));
        }
        public virtual void BeforeAction(CommanderBase at, CommanderBase df)
        {

        }
        protected int actionCount = 0;
        protected double actionAmount = 0;
        public virtual void AfterAction(CommanderBase at, CommanderBase df)
        {

        }
    }
}
