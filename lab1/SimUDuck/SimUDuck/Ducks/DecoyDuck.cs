using SimUDuck.DuckBehaviors.QuackBehavior;
using SimUDuck.DuckBehaviors.FlyBehavior;
using SimUDuck.DuckBehaviors.DanceBehavior;

namespace SimUDuck.Ducks;

public class DecoyDuck : Duck
{
    public DecoyDuck() : base(new FlyNoWay(), new MuteQuack(), new DanceNoWay())
    { }
}
