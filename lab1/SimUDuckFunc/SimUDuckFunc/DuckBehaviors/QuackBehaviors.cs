namespace SimUDuckFunc.DuckBehaviors;

public class QuackBehaviors
{
    public static readonly Action Quack = () => Console.WriteLine("Quack");
    public static readonly Action Squeak = () => Console.WriteLine("Squeak");
    public static readonly Action Mute = () => { };
}
