namespace SimUDuck.DuckBehaviors.QuackBehavior;

public class Squeak : IQuackBehavior
{
    public void Quack()
    {
        Console.WriteLine("Squeak");
    }
}
