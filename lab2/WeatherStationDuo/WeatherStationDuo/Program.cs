using WeatherStationDuo.Observer;
using WeatherStationDuo.Observable;

WeatherData wd = new();
WeatherDataOutside wdOut = new();

Display display = new(wd, wdOut);
StatsDisplay statsDisplay = new(wd, wdOut);

wd.RegisterObserver(display, 1);
wd.RegisterObserver(statsDisplay, 1);
wdOut.RegisterObserver(display, 1);
wdOut.RegisterObserver(statsDisplay, 2);

wd.UpdateWeatherInfo(3, 0.7, 760);
wdOut.UpdateWeatherInfo(4, 0.8, 761);

wd.RemoveObserver(statsDisplay);
wd.UpdateWeatherInfo(10, 0.8, 761);
wdOut.UpdateWeatherInfo(-10, 0.8, 76);