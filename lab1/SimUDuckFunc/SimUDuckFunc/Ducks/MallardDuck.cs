using SimUDuckFunc.DuckBehaviors;

namespace SimUDuckFunc.Ducks;

public class MallardDuck : Duck
{
    public MallardDuck() : base(FlyBehavior.FlyWithWings, DanceBehavior.Waltz, QuackBehavior.Quack)
    { }
}
