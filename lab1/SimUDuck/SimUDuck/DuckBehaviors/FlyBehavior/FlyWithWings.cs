using SimUDuck.DuckBehaviors.FlyCounterBehavior;

namespace SimUDuck.DuckBehaviors.FlyBehavior;

public class FlyWithWings : IFlyBehavior
{
    private int _counterFlying = 0;

    public void Fly()
    {
        Console.WriteLine("Fly");
        _counterFlying++;
        Console.WriteLine($"Departure number: {_counterFlying}");
    }
}
