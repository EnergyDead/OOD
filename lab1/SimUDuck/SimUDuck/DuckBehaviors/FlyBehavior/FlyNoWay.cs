namespace SimUDuck.DuckBehaviors.FlyBehavior;

public class FlyNoWay : IFlyBehavior
{
    public void Fly()
    {
        Console.WriteLine("Can't fly");
    }
}
