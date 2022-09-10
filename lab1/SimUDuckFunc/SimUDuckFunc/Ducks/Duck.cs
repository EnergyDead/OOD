using SimUDuckFunc.DuckBehaviors;

namespace SimUDuckFunc.Ducks;

public class Duck
{
    Action _flyBehavior;
    Action _danceBehavior;
    Action _quackBehavior;

    public Action FlyBehavior
    {
        get => _flyBehavior;
        set => _flyBehavior = value ?? throw new ArgumentNullException();
    }

    public Action DanceBehavior
    {
        get => _danceBehavior;
        set => _danceBehavior = value ?? throw new ArgumentNullException();
    }

    public Action QuackBehavior
    {
        get => _quackBehavior;
        set => _quackBehavior = value ?? throw new ArgumentNullException();
    }

    public Duck()
    {
        _flyBehavior = FlyBehaviors.FlyWithWings;
        _danceBehavior = DanceBehaviors.Dance;
        _quackBehavior = QuackBehaviors.Quack;
    }

    public Duck(
        Action flyBehavior,
        Action danceBehavior,
        Action quackBehavior)
    {
        _flyBehavior = flyBehavior ?? throw new ArgumentNullException(nameof(flyBehavior));
        _danceBehavior = danceBehavior ?? throw new ArgumentNullException(nameof(danceBehavior));
        _quackBehavior = quackBehavior ?? throw new ArgumentNullException(nameof(quackBehavior));
    }

    public void Dance()
    {
        _danceBehavior.Invoke();
    }

    public void Quack()
    {
        _quackBehavior.Invoke();
    }

    public void Fly()
    {
        _flyBehavior.Invoke();
    }

    public virtual void Swim()
    {
        Console.WriteLine("Swiming");
    }

    public virtual void Display()
    {
        Console.WriteLine("I`m simple duck.");
    }
}
