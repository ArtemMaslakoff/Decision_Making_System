namespace DecisionMakingLibrary.World
{
    public class Action<A, B, C>
    {
#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
#pragma warning disable CS0169 // Поле "Action<A, B, C>.function" никогда не используется.
        Func<A, B, C> function;
#pragma warning restore CS0169 // Поле "Action<A, B, C>.function" никогда не используется.
#pragma warning restore CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
    }
}
