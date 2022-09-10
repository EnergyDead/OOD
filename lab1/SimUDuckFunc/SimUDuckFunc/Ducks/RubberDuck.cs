using SimUDuckFunc.DuckBehaviors;

namespace SimUDuckFunc.Ducks;

public class RubberDuck : Duck
{
    public RubberDuck() : base(FlyBehaviors.FlyNoWay, DanceBehaviors.DanceNoWay, QuackBehaviors.Squeak)
    { }

    public override void Display()
    {
        Console.WriteLine("I`m RubberDuck.");
    }
}
