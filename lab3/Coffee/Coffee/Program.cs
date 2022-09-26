using Coffee.Beverage;
using Coffee.Beverage.Enums;
using Coffee.Condiment;
using Coffee.Condiment.Enums;

IBeverage drink = new Milkshake(AmountType.Big)
    .AddCream()
    .AddCream()
    .AddChocolateCrumbs(6)
    .AddChocolateSlices(4)
    .AddLiquor(LiquorType.Nutty)
    .AddSyrop(SyrupType.Chocolate);

Console.WriteLine(drink.Description());
Console.WriteLine($"Price: {drink.Cost()} $");