using SimUDuckFunc.Ducks;

List<Duck> ducks = new()
{
    new Duck(),
    new DecoyDuck(),
    new RubberDuck(),
    new MallardDuck(),
    new RedHeadDuck()
};

ducks[0].Fly();
ducks[0].Fly();

foreach (Duck duck in ducks)
{
    duck.Display();
    duck.Swim();
    duck.Quack();
    duck.Fly();
    duck.Dance();
    Console.WriteLine();
}