namespace WeatherStationDuo.Observable;

public class WeatherData : Observable<WeatherInfo>
{
    readonly double _defTemperature = 0.0;
    readonly double _defHumidity;
    readonly double _defPressure = 760.0;

    private WeatherInfo? _weatherInfo;
    public WeatherInfo WeatherInfo
    {
        get { return _weatherInfo ?? new WeatherInfo(_defTemperature, _defHumidity, _defPressure); }
        private set { _weatherInfo = value; }
    }

    public void MeasurementsChanged()
    {
        NotifyObservers();
    }

    public void UpdateWeatherInfo(double temperature, double humidity, double pressure)
    {
        WeatherInfo = new WeatherInfo(temperature, humidity, pressure);

        MeasurementsChanged();
    }

    protected override WeatherInfo GetModifiedData()
    {
        return WeatherInfo;
    }
}