namespace WeatherStationStandart.Observable;

public abstract class Observable<T> : IObservable<T>
{
    private readonly SortedSet<PriorityObserver> _observers = new(new PriorityObserverComparer());

    public void NotifyObservers()
    {
        var newObservers = _observers.ToList();
        var data = GetModifiedData();

        foreach (var observer in newObservers)
            observer.Observer.Update(data);
    }

    public void RegisterObserver(Observer.IObserver<T> observer, int ptiority = 0)
    {
        if (observer == null) throw new ArgumentNullException(nameof(observer));
        var newObserver = new PriorityObserver(observer, ptiority);
        if (!_observers.Contains(newObserver))
            _observers.Add(newObserver);
    }

    public void RemoveObserver(Observer.IObserver<T> observer)
    {
        _observers.RemoveWhere(o => o.Observer == observer);
    }

    protected abstract T GetModifiedData();

    private class PriorityObserver
    {
        public int Priority { get; private set; }
        public Observer.IObserver<T> Observer { get; private set; }

        public PriorityObserver(Observer.IObserver<T> observer, int ptiority)
        {
            Priority = ptiority;
            Observer = observer;
        }
    }

    private class PriorityObserverComparer : IComparer<PriorityObserver>
    {
        public int Compare(PriorityObserver x, PriorityObserver y)
        {
            if (ReferenceEquals(x.Observer, y.Observer))
            {
                return 0;
            }
            else if (x.Priority == y.Priority)
            {
                return 1;
            }
            else
            {
                return y.Priority - x.Priority;
            }
        }
    }
}
