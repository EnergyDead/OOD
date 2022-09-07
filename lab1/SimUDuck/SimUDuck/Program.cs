using SimUDuck.Ducks;

List<Duck> ducks = new()
{
    new Duck(),
    new DecoyDuck(),
    new RubberDuck(),
    new MallardDuck(),
    new RedHeadDuck()
};

foreach (Duck duck in ducks)
{
    Console.WriteLine($"{duck.GetType()} can perform:");
    duck.PerformDance();
    duck.PerformQuack();
    duck.PerformFly();
    duck.Swim();
    duck.Display();
    Console.WriteLine();
}