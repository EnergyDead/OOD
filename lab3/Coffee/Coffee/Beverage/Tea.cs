using Coffee.Beverage.Enums;

namespace Coffee.Beverage;

internal class Tea : BeverageBase
{
    public Tea(TeaType teaType) : base($"{teaType} tea")
    {
    }

    public override double Cost()
    {
        return 30;
    }
}
