using Coffee.Beverage;

namespace Coffee.Condiment;

internal class ChocolateSlices : CondimentDecorator
{
    private readonly uint _quantity;
    private readonly uint _maxSlices = 5;
    public ChocolateSlices(IBeverage beverage, uint quantity) : base(beverage)
    {
        _quantity = quantity > _maxSlices ? _maxSlices : quantity;
    }

    protected override double GetCondimentCost() => 10 * _quantity;

    protected override string GetCondimentDescription() => $"Chocolate slices x {_quantity}";
}
