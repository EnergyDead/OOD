using SimUDuckFunc.DuckBehaviors;

namespace SimUDuckFunc.Ducks;

public class DecoyDuck : Duck
{
    public DecoyDuck() : base(FlyBehavior.FlyNoWay, DanceBehavior.DanceNoWay, QuackBehavior.Quack)
    { }
}
