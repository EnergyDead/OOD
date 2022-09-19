namespace WeatherStationStandart.Observable;

public interface IObservable<T>
{
    void RegisterObserver(Observer.IObserver<T> observer, int ptiorit);
    void RemoveObserver(Observer.IObserver<T> observer);
    void NotifyObservers();
}
