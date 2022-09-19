using WeatherStationDuo.Observable;

namespace WeatherStationDuo.Observer;

public class Display : IObserver<WeatherInfo>
{
    private readonly Observable.IObservable<WeatherInfo> _inSubject;
    private readonly Observable.IObservable<WeatherInfo> _outSubject;
    
    public Display(Observable.IObservable<WeatherInfo> inSub, Observable.IObservable<WeatherInfo> outSub)
    {
        _inSubject = inSub;
        _outSubject = outSub;
    }

    public void Update(Observable.IObservable<WeatherInfo> subject, WeatherInfo data)
    {
        if(subject == _inSubject)
        {
            Console.WriteLine("Subject in inside.");
        }
        else if(subject == _outSubject)
        {
            Console.WriteLine("Subject in outside.");
        }

        Console.WriteLine($"Current temperature {data.Temperature}");
        Console.WriteLine($"Current humidity {data.Humidity}");
        Console.WriteLine($"Current pressure {data.Pressure}");
        Console.WriteLine("---------------");
    }
}
