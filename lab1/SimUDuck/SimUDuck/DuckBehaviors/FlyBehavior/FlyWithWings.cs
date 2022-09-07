using SimUDuck.DuckBehaviors.FlyCounterBehavior;

namespace SimUDuck.DuckBehaviors.FlyBehavior;

public class FlyWithWings : IFlyBehavior
{
    readonly IFlyCounterBehavior _flyCounterBehavior;

    public FlyWithWings(IFlyCounterBehavior flyCounterBehavior)
    {
        _flyCounterBehavior = flyCounterBehavior ?? throw new ArgumentNullException(nameof(flyCounterBehavior));
    }

    public void Fly()
    {
        Console.WriteLine("Fly");
        _flyCounterBehavior.TakeWing();
    }
}
