using SimUDuckFunc.Ducks;

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
    duck.Dance();
    duck.Quack();
    duck.Fly();
    duck.Swim();
    duck.Display();
    Console.WriteLine();
}