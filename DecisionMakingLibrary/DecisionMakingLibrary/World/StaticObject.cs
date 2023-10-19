using DecisionMakingLibrary.Core;

namespace DecisionMakingLibrary.World
{
    public class StaticObject : Object
    {
        public StaticObject(string name, List<Value<IValue>> parameters) : base(name, parameters)
        {
        }
    }
}
