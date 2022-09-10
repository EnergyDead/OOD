namespace SimUDuckFunc.DuckBehaviors;

public class FlyBehaviors
{
    public static Action FlyWithWings()
    {
        int flightsAmount = 0;

        return () =>
        {
            ++flightsAmount;
            Console.WriteLine($"Fly");
            Console.WriteLine($"Flight number:{flightsAmount}");
        };
    }

    public static void FlyNoWay() => Console.WriteLine("Can`t fly");
}
