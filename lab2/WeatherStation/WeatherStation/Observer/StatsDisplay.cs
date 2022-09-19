using WeatherStation.Observiable;

namespace WeatherStation.Observer;

public class StatsDisplay : IObserver<WeatherInfo>
{
    private readonly List<MeasurementStatistic> _statistics = new()
    {
        new MeasurementStatistic(WeatherMeasure.Temperature, wi => wi.Temperature),
        new MeasurementStatistic(WeatherMeasure.Humidity, wi => wi.Humidity),
        new MeasurementStatistic(WeatherMeasure.Pressure, wi => wi.Pressure),
    };

    public void Update(WeatherInfo data)
    {
        foreach (MeasurementStatistic statistic in _statistics)
        {
            statistic.Update(data);
            statistic.Display();
        }
        Console.WriteLine("---------------");
    }

    class MeasurementStatistic
    {
        private readonly Func<WeatherInfo, double> _extractor;
        private readonly WeatherMeasure _weatherMeasure;
        private double _minimal;
        private double _maximal;
        private double _total;
        private int _accCount;

        public double Avarage => _accCount == 0 ? 0 : _total / _accCount;

        public MeasurementStatistic(WeatherMeasure weatherMeasure, Func<WeatherInfo, double> extractor)
        {
            _weatherMeasure = weatherMeasure;
            _extractor = extractor;
        }

        public void Update(WeatherInfo data)
        {
            var value = _extractor(data);

            if (value > _maximal)
                _maximal = value;
            else if (value < _minimal)
                _minimal = value;

            _total += value;
            _accCount++;
        }

        public void Display()
        {
            Console.WriteLine($"Maximal {_weatherMeasure}: {_maximal:0.##}");
            Console.WriteLine($"Minimal {_weatherMeasure}: {_minimal:0.##}");
            Console.WriteLine($"Avarage {_weatherMeasure}: {Avarage:0.##}");
        }
    }
}
