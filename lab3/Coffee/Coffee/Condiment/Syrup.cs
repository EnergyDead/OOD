using Coffee.Beverage;
using Coffee.Condiment.Enums;

namespace Coffee.Condiment;

internal class Syrup : CondimentDecorator
{
    private readonly SyrupType _syrupType;
    public Syrup(IBeverage beverage, SyrupType syrupType) : base(beverage)
    {
        _syrupType = syrupType;
    }

    protected override double GetCondimentCost() => 15;

    protected override string GetCondimentDescription() => $"{_syrupType} syrup";
}
