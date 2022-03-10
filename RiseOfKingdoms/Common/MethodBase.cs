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
    }
}
