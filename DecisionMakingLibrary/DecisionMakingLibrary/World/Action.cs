using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionMakingLibrary.World
{
    public class Action<A, B, C>
    {
        Func<A, B, C> function;
    }
}
