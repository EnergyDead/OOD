namespace SimUDuckFunc.DuckBehaviors;

public class QuackBehavior
{
    public static readonly Action Quack = () => Console.WriteLine("Quack");
    public static readonly Action Squeak = () => Console.WriteLine("Squeak");
}
