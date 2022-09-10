using SimUDuck.DuckBehaviors.FlyCounterBehavior;

namespace SimUDuck.DuckBehaviors.FlyBehavior;

public class FlyWithWings : IFlyBehavior
{
    readonly IFlyCounterBehavior _flyCounterBehavior;

    public FlyWithWings()
    {
        _flyCounterBehavior = new FlightCounter();
    }

    public void Fly()
    {
        Console.WriteLine("Fly");
        _flyCounterBehavior.TakeWing();
    }
}
