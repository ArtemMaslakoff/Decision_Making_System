using DecisionMakingLibrary.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionMakingLibrary.World.World_objects
{
    public class CompositeObject : Object
    {
        public CompositeObject(string name, List<Value<IValue>> parameters) : base(name, parameters)
        {
        }
    }
}
