namespace SimUDuck.DuckBehaviors.QuackBehavior;

public class Quack : IQuackBehavior
{
    void IQuackBehavior.Quack() // избавиться от IQuackBehavior.
    {
        Console.WriteLine("Quack");
    }
}
