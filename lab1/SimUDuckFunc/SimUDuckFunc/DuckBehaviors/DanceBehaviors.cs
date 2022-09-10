namespace SimUDuckFunc.DuckBehaviors;

public class DanceBehaviors
{
    public static readonly Action Dance = () => Console.WriteLine("Dance");
    public static readonly Action DanceNoWay = () => Console.WriteLine("Can`t dance");
    public static readonly Action Minuet = () => Console.WriteLine("Minuet");
    public static readonly Action Waltz = () => Console.WriteLine("Waltz");
}
