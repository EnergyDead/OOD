using Coffee.Beverage;
using Coffee.Condiment.Enums;

namespace Coffee.Condiment;

internal static class IBeverageBuilderExtension
{
    public static IBeverage AddSyrop(this IBeverage beverage, SyrupType syrupType) => new Syrup(beverage, syrupType);
    public static IBeverage AddChocolateCrumbs(this IBeverage beverage, uint mass) => new ChocolateCrumbs(beverage, mass);
    public static IBeverage AddChocolateSlices(this IBeverage beverage, uint quantity) => 
        new ChocolateSlices(beverage, quantity);
    public static IBeverage AddCinnamon(this IBeverage beverage) => new Cinnamon(beverage);
    public static IBeverage AddCoconutFlakes(this IBeverage beverage, uint mass) => new CoconutFlakes(beverage, mass);
    public static IBeverage AddCream(this IBeverage beverage) => new Cream(beverage);
    public static IBeverage AddIceCubes(this IBeverage beverage, uint quantity, IceCubeType iceCubeType = IceCubeType.Water) =>
        new IceCube(beverage, quantity, iceCubeType);
    public static IBeverage AddLemon(this IBeverage beverage, uint quantity = 1) => new Lemon(beverage, quantity);
    public static IBeverage AddLiquor(this IBeverage beverage, LiquorType liquorType) => new Liquor(beverage, liquorType);
}
