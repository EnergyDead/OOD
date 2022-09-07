namespace SimUDuck.DuckBehaviors.QuackBehavior;

public class Quack : IQuackBehavior
{
    void IQuackBehavior.Quack()
    {
        Console.WriteLine("Quack");
    }
}
