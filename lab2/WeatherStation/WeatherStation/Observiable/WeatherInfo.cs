namespace WeatherStation.Observiable;

public class WeatherInfo
{
    public WeatherInfo(double temperature, double humidity, double pressure)
    {
        Temperature = temperature;
        Humidity = humidity;
        Pressure = pressure;
    }

    public double Temperature { get; private set; }
    public double Humidity { get; private set; }
    public double Pressure { get; private set; }
}

public enum WeatherMeasure
{
    Temperature,
    Humidity,
    Pressure
}