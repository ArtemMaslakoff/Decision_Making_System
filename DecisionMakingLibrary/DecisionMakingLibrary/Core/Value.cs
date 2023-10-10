using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionMakingLibrary.Core
{
    public class Value<T> : ICloneable, IValue
    {
        private Notion notion;
        private T meaning;
        public Value(Notion notion, T meaning)
        {
            this.notion = notion;
            this.meaning = meaning;
        }
        public object Clone()
        {
            return new Value<T>((Notion)notion.Clone(), meaning);
        }
        public override string ToString()
        {
            return "---Value---\n" + notion.ToString() + "\n" + "Value Meaning: " + meaning.ToString() + "\n-----------";
        }
        public override bool Equals(object? obj)
        {
            if (obj == null)
            {
                throw new Exception("Null imported object");
            }
            try
            {
                if (notion == ((Value<T>)obj).notion && Equals(meaning, ((Value<T>)obj).meaning))
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

        public Notion GetNotion()
        {
            return notion;
        }

        public object GetMeaning()
        {
            return meaning;
        }
    }
    public interface IValue
    {
        public Notion GetNotion();
        public object GetMeaning();
    }
}
