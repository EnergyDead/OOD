using Moq;
using System;
using WeatherStationStandart.Observable;
using Observer = WeatherStationStandart.Observer;
using Xunit;

namespace WeatherStationStandartTests;

public class ObserverPriorityTests
{
    [Fact]
    public void ObserverPriorityTest()
    {
        // arrange
        var wd = new WeatherData();
        var first = new Mock<Observer.IObserver<WeatherInfo>>();
        var second = new Mock<Observer.IObserver<WeatherInfo>>();

        DateTime? UpdatedTimeByFirst = default;
        DateTime? UpdatedTimeBySecond = default;
        first.Setup(o => o.Update(It.IsAny<WeatherInfo>())).Callback(() => UpdatedTimeByFirst = DateTime.Now);
        second.Setup(o => o.Update(It.IsAny<WeatherInfo>())).Callback(() => UpdatedTimeBySecond = DateTime.Now);

        wd.RegisterObserver(first.Object, 3);
        wd.RegisterObserver(second.Object, 5);

        // act
        wd.UpdateWeatherInfo(1, 2, 3);

        // assert
        Assert.True(UpdatedTimeByFirst > UpdatedTimeBySecond);
    }
}
