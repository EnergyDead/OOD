namespace WeatherStation.Observiable;

public abstract class Observiable<T> : IObserviable<T>
{
    private readonly List<Observer.IObserver<T>> _observers = new();

    public void NotifyObservers()
    {
        var newObservers = _observers.ToList();
        var data = GetModifiedData();

        foreach (var observer in newObservers)
            observer.Update(data);
    }

    public void RegisterObserver(Observer.IObserver<T> observer)
    {
        if (observer == null) throw new ArgumentNullException(nameof(observer));

        _observers.Add(observer);
    }

    public void RemoveObserver(Observer.IObserver<T> observer)
    {
        _observers.RemoveAll(o => o == observer);
    }

    protected abstract T GetModifiedData();
}