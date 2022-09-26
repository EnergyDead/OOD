using Coffee.Beverage;

namespace Coffee.Condiment;

internal class CoconutFlakes : CondimentDecorator
{
    private readonly uint _mass;
    public CoconutFlakes(IBeverage beverage, uint mass) : base(beverage)
    {
        _mass = mass;
    }

    protected override double GetCondimentCost() => 1 * _mass;

    protected override string GetCondimentDescription() => $"Coconut flakes {_mass} g";
}
