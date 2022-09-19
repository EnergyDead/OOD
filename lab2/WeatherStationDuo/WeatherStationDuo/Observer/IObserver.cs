namespace WeatherStationDuo.Observer;

public interface IObserver<T>
{
    void Update(Observable.IObservable<T> subject, T data);
}
