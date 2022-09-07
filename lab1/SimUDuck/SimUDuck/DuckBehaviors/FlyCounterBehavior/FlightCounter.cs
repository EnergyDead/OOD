namespace SimUDuck.DuckBehaviors.FlyCounterBehavior;

public class FlightCounter : IFlyCounterBehavior
{
    private int _counterFlying = 0;
    public void TakeWing()
    {
        _counterFlying++;
        Console.WriteLine($"Departure number: {_counterFlying}");
    }
}
