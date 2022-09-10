using SimUDuckFunc.DuckBehaviors;

namespace SimUDuckFunc.Ducks;

public class RedHeadDuck : Duck
{
    public RedHeadDuck() : base(FlyBehaviors.FlyWithWings, DanceBehaviors.Minuet, QuackBehaviors.Quack)
    { }

    public override void Display()
    {
        Console.WriteLine("I`m RedHeadDuck.");
    }
}
