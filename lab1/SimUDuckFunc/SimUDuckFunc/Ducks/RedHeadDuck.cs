using SimUDuckFunc.DuckBehaviors;

namespace SimUDuckFunc.Ducks;

public class RedHeadDuck : Duck
{
    public RedHeadDuck() : base(FlyBehavior.FlyWithWings, DanceBehavior.Minuet, QuackBehavior.Quack)
    { }
}
