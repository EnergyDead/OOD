using SimUDuck.DuckBehaviors.DanceBehavior;
using SimUDuck.DuckBehaviors.FlyBehavior;
using SimUDuck.DuckBehaviors.FlyCounterBehavior;
using SimUDuck.DuckBehaviors.QuackBehavior;

namespace SimUDuck.Ducks;

public class RedHeadDuck : Duck
{
    public RedHeadDuck() : base(new FlyWithWings(), new Quack(), new Minuet())
    { }
}
