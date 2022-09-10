namespace SimUDuckFunc.DuckBehaviors;

public class FlyBehaviors
{
    public static Action FlyWithWings()
    {
        var flightCounter = FlightCounter();
        return () =>
        {
            Console.WriteLine($"Fly");
            flightCounter();
        };
    }

    public static void FlyNoWay() => Console.WriteLine("Can`t fly");

    static Action FlightCounter()
    {
        int flightsAmount = 0;

        return () =>
        {
            ++flightsAmount;
            Console.WriteLine($"Flight number:{flightsAmount}");
        };
    }
}
