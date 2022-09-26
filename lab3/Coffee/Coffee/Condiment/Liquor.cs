using Coffee.Beverage;
using Coffee.Condiment.Enums;

namespace Coffee.Condiment;

internal class Liquor : CondimentDecorator
{
    private readonly LiquorType _liquorType;
    public Liquor(IBeverage beverage, LiquorType liquorType) : base(beverage)
    {
        _liquorType = liquorType;
    }

    protected override double GetCondimentCost() => 50;

    protected override string GetCondimentDescription() => $"{_liquorType} liquor";
}
