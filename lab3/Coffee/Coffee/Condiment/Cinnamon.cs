using Coffee.Beverage;

namespace Coffee.Condiment;

internal class Cinnamon : CondimentDecorator
{
    public Cinnamon(IBeverage beverage) : base(beverage)
    {
    }

    protected override double GetCondimentCost() => 20;

    protected override string GetCondimentDescription() => "Cinnamon";
}
