using WeatherStationStandart.Observer;
using WeatherStationStandart.Observable;
using Xunit;

namespace WeatherStationStandartTests;

public class ObserverTests
{
    [Fact]
    public void UnsubscribeWhenUpdatingTest()
    {
        //Arrange
        WeatherData wd = new();
        Display display = new();
        NewDisplay brokenDisplay = new(wd);

        wd.RegisterObserver(display);
        wd.RegisterObserver(brokenDisplay);

        //Act
        var ex = Record.Exception(() => wd.UpdateWeatherInfo(1, 1, 1));

        //Assert
        Assert.Null(ex);
    }

    class NewDisplay : IObserver<WeatherInfo>
    {
        Observable<WeatherInfo> _observer;
        public NewDisplay(Observable<WeatherInfo> observiable)
        {
            _observer = observiable;
        }

        public void Update(WeatherInfo data)
        {
            _observer.RemoveObserver(this);
        }
    }

}
