namespace Coffee.Beverage;

internal abstract class BeverageBase : IBeverage
{
    private readonly string _description;

    public BeverageBase(string description)
    {
        _description = description;
    }

    public string Description() => _description;

    public abstract double Cost();
}
