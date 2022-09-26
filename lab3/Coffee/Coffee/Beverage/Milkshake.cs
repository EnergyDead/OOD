using Coffee.Beverage.Enums;

namespace Coffee.Beverage;

internal class Milkshake : BeverageBase
{
    private readonly AmountType _amountType;

    public Milkshake(AmountType amountType) : base($"{amountType} milkshake")
    {
        _amountType = amountType;
    }

    public override double Cost()
    {
        return _amountType switch
        {
            AmountType.Small => 50,
            AmountType.Middle => 60,
            AmountType.Big => 80,
            _ => 80,
        };
    }
}
