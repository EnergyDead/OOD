using SimUDuck.DuckBehaviors.DanceBehavior;
using SimUDuck.DuckBehaviors.FlyBehavior;
using SimUDuck.DuckBehaviors.FlyCounterBehavior;
using SimUDuck.DuckBehaviors.QuackBehavior;

namespace SimUDuck.Ducks;

public class MallardDuck : Duck
{
    public MallardDuck() : base(new FlyWithWings(new FlightCounter()), new Quack(), new Waltz())
    { }
}
