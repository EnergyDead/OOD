namespace SimUDuckFunc.DuckBehaviors;

public class FlyBehaviors
{
    public static Action FlyWithWings()
    {
        int flightsAmount = 0;

        return () =>
        {
            Console.WriteLine($"Fly");

            ++flightsAmount;
            Console.WriteLine($"Flight number:{flightsAmount}");
        };
    }

    public static void FlyNoWay() => Console.WriteLine("Can`t fly");
}
