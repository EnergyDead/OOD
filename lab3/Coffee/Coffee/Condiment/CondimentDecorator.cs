using Coffee.Beverage;

namespace Coffee.Condiment;

internal abstract class CondimentDecorator : IBeverage
{
    private readonly IBeverage _beverage;

    protected CondimentDecorator(IBeverage beverage)
    {
        _beverage = beverage;
    }

    public double Cost()
    {
        return _beverage.Cost() + GetCondimentCost();
    }

    public string Description()
    {
        return $"{_beverage.Description()}, {GetCondimentDescription()}";
    }

    protected abstract string GetCondimentDescription();

    protected abstract double GetCondimentCost();
}
