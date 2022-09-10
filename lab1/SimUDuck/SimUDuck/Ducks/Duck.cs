using SimUDuck.DuckBehaviors.QuackBehavior;
using SimUDuck.DuckBehaviors.FlyBehavior;
using SimUDuck.DuckBehaviors.DanceBehavior;

namespace SimUDuck.Ducks;

public class Duck
{
    readonly IFlyBehavior _flyBehavior;
    readonly IQuackBehavior _quackBehavior;
    readonly IDanceBehavior _danceBehavior;

    public Duck()
    {
        _flyBehavior = new FlyWithWings();
        _quackBehavior = new Quack();
        _danceBehavior = new Flex();
    }

    public Duck(
        IFlyBehavior flyBehavior,
        IQuackBehavior quackBehavior,
        IDanceBehavior danceBehavior)
    {
        _flyBehavior = flyBehavior ?? throw new ArgumentNullException(nameof(flyBehavior));
        _quackBehavior = quackBehavior ?? throw new ArgumentNullException(nameof(quackBehavior));
        _danceBehavior = danceBehavior ?? throw new ArgumentNullException(nameof(danceBehavior));
    }

    public void PerformDance()
    {
        _danceBehavior.Dance();
    }

    public void PerformQuack()
    {
        _quackBehavior.Quack();
    }

    public void PerformFly()
    {
        _flyBehavior.Fly();
    }

    public virtual void Swim()
    {
        Console.WriteLine("Swiming");
    }

    public virtual void Display()
    {
        Console.WriteLine("Show yourself");
    }
}
