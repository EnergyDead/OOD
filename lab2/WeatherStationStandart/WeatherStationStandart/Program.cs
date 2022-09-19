using WeatherStationStandart.Observer;
using WeatherStationStandart.Observable;

WeatherData wd = new();

Display display = new();
wd.RegisterObserver(display, 1);
StatsDisplay statsDisplay = new();
wd.RegisterObserver(statsDisplay, 2);

wd.UpdateWeatherInfo(3, 0.7, 760);
wd.UpdateWeatherInfo(4, 0.8, 761);

wd.RemoveObserver(statsDisplay);
wd.UpdateWeatherInfo(10, 0.8, 761);
wd.UpdateWeatherInfo(-10, 0.8, 76);