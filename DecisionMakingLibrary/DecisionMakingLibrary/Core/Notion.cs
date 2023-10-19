namespace DecisionMakingLibrary.Core
{
#pragma warning disable CS0660 // Тип определяет оператор == или оператор !=, но не переопределяет Object.Equals(object o)
#pragma warning disable CS0661 // Тип определяет оператор == или оператор !=, но не переопределяет Object.GetHashCode()
    public class Notion : ICloneable
#pragma warning restore CS0661 // Тип определяет оператор == или оператор !=, но не переопределяет Object.GetHashCode()
#pragma warning restore CS0660 // Тип определяет оператор == или оператор !=, но не переопределяет Object.Equals(object o)
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
        public static bool operator ==(Notion left, Notion right)
        {
            return left.Name == right.Name;
        }
        public static bool operator !=(Notion left, Notion right)
        {
            return left.Name != right.Name;
        }
    }
}