using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionMakingLibrary
{
    public class Value<T> : ICloneable
    {
        public Notion Notion { get; }
        public T Meaning { get; set; }
        public Value(Notion notion, T meaning)
        {
            Notion = notion;
            Meaning = meaning;
        }

        public object Clone()
        {
            return new Value<T>((Notion)Notion.Clone(), Meaning);
        }

        public override bool Equals(object? obj)
        {
            if (obj == null)
            {
                throw new Exception("Null imported object");
            }
            try
            {
                if (this.Notion == ((Value<T>)obj).Notion && Equals(this.Meaning, ((Value<T>)obj).Meaning))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                throw new NotImplementedException();
            }
        }
    }
}
