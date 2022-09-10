namespace SimUDuckFunc.DuckBehaviors;

public class FlyBehaviors
{
    public static readonly Action FlyWithWings = delegate ()
    {
        Console.WriteLine("Fly");
    };

    public static readonly Action FlyNoWay = delegate ()
    {
        Console.WriteLine("Can`t fly");
    };
}
