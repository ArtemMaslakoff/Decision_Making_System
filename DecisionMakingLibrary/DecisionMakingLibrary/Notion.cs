namespace DecisionMakingLibrary
{
    public class Notion : ICloneable
    {
        public string Name { get; }
        public Notion()
        {
            Name = string.Empty;
        }
        public Notion(string name)
        {
            Name = name;
        }
        public object Clone()
        {
            return new Notion((string)Name.Clone());
        }
        public override string ToString()
        {
            return "Notion Name: " + Name;
        }
        public static bool operator == (Notion left, Notion right)
        {
            return left.Name == right.Name;
        }
        public static bool operator !=(Notion left, Notion right)
        {
            return left.Name != right.Name;
        }
    }
}