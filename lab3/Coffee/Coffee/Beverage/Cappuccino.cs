using Coffee.Beverage.Enums;

namespace Coffee.Beverage;

internal class Cappuccino : Coffee
{
    private readonly QuantityType _quantityType;

    public Cappuccino(QuantityType quantityType) : base($"{quantityType} Cappuccino")
    {
        _quantityType = quantityType;
    }

    public override double Cost()
    {
        return _quantityType == QuantityType.Single ? 80 : 120;
    }
}
