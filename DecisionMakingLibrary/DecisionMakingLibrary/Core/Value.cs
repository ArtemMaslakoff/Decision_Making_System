namespace DecisionMakingLibrary.Core
{
#pragma warning disable CS0659 // Тип переопределяет Object.Equals(object o), но не переопределяет Object.GetHashCode()
    public class Value<T> : ICloneable, IValue
#pragma warning restore CS0659 // Тип переопределяет Object.Equals(object o), но не переопределяет Object.GetHashCode()
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
#pragma warning disable CS8602 // Разыменование вероятной пустой ссылки.
            return "---Value---\n" + notion.ToString() + "\n" + "Value Meaning: " + meaning.ToString() + "\n-----------";
#pragma warning restore CS8602 // Разыменование вероятной пустой ссылки.
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
#pragma warning disable CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
            return meaning;
#pragma warning restore CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
        }
    }
    public interface IValue
    {
        public Notion GetNotion();
        public object GetMeaning();
    }
}
