namespace Coffee.Beverage;

internal class Coffee : BeverageBase
{
    public Coffee(string description = "Coffee") : base(description)
    {
    }

    public override double Cost()
    {
        return 60;
    }
}
