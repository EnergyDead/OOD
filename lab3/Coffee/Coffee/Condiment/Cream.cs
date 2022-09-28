using Coffee.Beverage;

namespace Coffee.Condiment;

internal class Cream : CondimentDecorator
{
    public Cream(IBeverage beverage) : base(beverage)
    {
    }

    protected override double GetCondimentCost() => 25;

    protected override string GetCondimentDescription() => $"Cream";
}
