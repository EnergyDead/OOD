using SimUDuckFunc.DuckBehaviors;

namespace SimUDuckFunc.Ducks;

public class DecoyDuck : Duck
{
    public DecoyDuck() : base(FlyBehaviors.FlyNoWay, DanceBehaviors.DanceNoWay, QuackBehaviors.Quack)
    { }
    public override void Display()
    {
        Console.WriteLine("I`m DecoyDuck.");
    }
}

