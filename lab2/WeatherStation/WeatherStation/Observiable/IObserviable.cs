namespace WeatherStation.Observiable;

public interface IObserviable<T>
{
    void RegisterObserver(Observer.IObserver<T> observer);
    void RemoveObserver(Observer.IObserver<T> observer);
    void NotifyObservers();
}
