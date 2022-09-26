using Coffee.Beverage;

namespace Coffee.Condiment;

internal class Lemon : CondimentDecorator
{
    private readonly uint _quantity;

    public Lemon(IBeverage beverage, uint quantity = 1) : base(beverage)
    {
        _quantity = quantity;
    }

    protected override double GetCondimentCost() => 10 * _quantity;

    protected override string GetCondimentDescription() => $"Lemon x {_quantity}";
}
