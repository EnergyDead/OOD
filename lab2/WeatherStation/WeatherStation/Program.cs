using WeatherStation.Observer;
using WeatherStation.Observiable;

var wd = new WeatherData();

Display display = new();
wd.RegisterObserver(display);
StatsDisplay statsDisplay = new();
wd.RegisterObserver(statsDisplay);

wd.UpdateWeatherInfo(3, 0.7, 760);
wd.UpdateWeatherInfo(4, 0.8, 761);

wd.RemoveObserver(statsDisplay);
wd.UpdateWeatherInfo(10, 0.8, 761);
wd.UpdateWeatherInfo(-10, 0.8, 76);