using SimUDuckFunc.DuckBehaviors;

namespace SimUDuckFunc.Ducks;

public class RubberDuck : Duck
{
    public RubberDuck() : base(FlyBehavior.FlyNoWay, DanceBehavior.DanceNoWay, QuackBehavior.Squeak)
    { }
}
