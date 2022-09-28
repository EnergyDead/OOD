using Coffee.Beverage;
using Coffee.Condiment.Enums;

namespace Coffee.Condiment;

internal class IceCube : CondimentDecorator
{
    private readonly IceCubeType _iceCubeType;
    private readonly uint _quantity;

    public IceCube(IBeverage beverage, uint quantity, IceCubeType iceCubeType = IceCubeType.Water) : base(beverage)
    {
        _iceCubeType = iceCubeType;
        _quantity = quantity;
    }

    protected override double GetCondimentCost()
    {
        return (_iceCubeType == IceCubeType.Dry ? 10 : 5) * _quantity;
    }

    protected override string GetCondimentDescription() => $"{_iceCubeType.ToString()} ice cubes x {_quantity}";
}
