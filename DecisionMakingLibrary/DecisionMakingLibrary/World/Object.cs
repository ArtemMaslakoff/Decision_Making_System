using DecisionMakingLibrary.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionMakingLibrary.World
{
    public class Object 
    {
        protected string Name { get; }
        protected List<Value<IValue>> Parameters { get; }
        public Object(string name, List<Value<IValue>> parameters)
        {
            Name = name;
            Parameters = parameters;
        }
    }
}
