using SimUDuck.DuckBehaviors.QuackBehavior;
using SimUDuck.DuckBehaviors.FlyBehavior;
using SimUDuck.DuckBehaviors.DanceBehavior;

namespace SimUDuck.Ducks;

public class Duck
{
    IFlyBehavior _flyBehavior;
    IQuackBehavior _quackBehavior;
    IDanceBehavior _danceBehavior;

    public IFlyBehavior FlyBehavior
    {
        get => _flyBehavior;
        set => _flyBehavior = value ?? throw new ArgumentNullException(nameof(value));
    }

    public IQuackBehavior QuackBehavior
    {
        get => _quackBehavior;
        set => _quackBehavior = value ?? throw new ArgumentNullException(nameof(value));
    }

    public IDanceBehavior DanceBehavior
    {
        get => _danceBehavior;
        set => _danceBehavior = value ?? throw new ArgumentNullException(nameof(value));
    }

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
