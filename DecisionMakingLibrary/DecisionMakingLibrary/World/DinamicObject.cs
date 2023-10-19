using DecisionMakingLibrary.Core;

namespace DecisionMakingLibrary.World
{
    public class DinamicObject : Object
    {
        public DinamicObject(string name, List<Value<IValue>> parameters) : base(name, parameters)
        {
        }
    }
}
