using Coffee.Beverage.Enums;

namespace Coffee.Beverage;

internal class Latte : Coffee
{
    private readonly QuantityType _quantityType;

    public Latte(QuantityType quantityType) : base($"{quantityType} latte")
    {
        _quantityType = quantityType;
    }

    public override double Cost()
    {
        return _quantityType == QuantityType.Single ? 90 : 130;
    }
}
