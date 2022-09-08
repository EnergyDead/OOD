namespace SimUDuckFunc.Ducks;

public class Duck
{
    readonly Action _flyBehavior;
    readonly Action _danceBehavior;
    readonly Action _quackBehavior;

    public Duck()
    {
        _flyBehavior = () => Console.WriteLine("Fly");
        _danceBehavior = () => Console.WriteLine("Flex");
        _quackBehavior = () => Console.WriteLine("Quack");
    }

    public Duck(
        Action flyBehavior,
        Action danceBehavior,
        Action quackBehavior)
    {
        _flyBehavior = flyBehavior;
        _danceBehavior = danceBehavior;
        _quackBehavior = quackBehavior;
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
        Console.WriteLine("Show yourself");
    }
}
