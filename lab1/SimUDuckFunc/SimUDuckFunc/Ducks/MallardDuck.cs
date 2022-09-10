using SimUDuckFunc.DuckBehaviors;

namespace SimUDuckFunc.Ducks;

public class MallardDuck : Duck
{
    public MallardDuck() : base(FlyBehaviors.FlyWithWings, DanceBehaviors.Waltz, QuackBehaviors.Quack)
    { }

    public override void Display()
    {
        Console.WriteLine("I`m MallardDuck.");
    }
}
