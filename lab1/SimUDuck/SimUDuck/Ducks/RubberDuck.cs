using SimUDuck.DuckBehaviors.DanceBehavior;
using SimUDuck.DuckBehaviors.FlyBehavior;
using SimUDuck.DuckBehaviors.QuackBehavior;

namespace SimUDuck.Ducks;

public class RubberDuck : Duck
{
    public RubberDuck() : base(new FlyNoWay(), new Squeak(), new DanceNoWay())
    { }
}
