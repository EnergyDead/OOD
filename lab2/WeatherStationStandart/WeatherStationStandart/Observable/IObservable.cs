namespace WeatherStationStandart.Observable;

public interface IObservable<T>
{
    void RegisterObserver(Observer.IObserver<T> observer, int priority);
    void RemoveObserver(Observer.IObserver<T> observer);
    void NotifyObservers();
}
