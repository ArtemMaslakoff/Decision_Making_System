using DecisionMakingLibrary.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionMakingLibrary.World
{
    public class StaticObject : Object
    {
        public StaticObject(string name, List<Value<IValue>> parameters) : base(name, parameters)
        {
        }
    }
}
