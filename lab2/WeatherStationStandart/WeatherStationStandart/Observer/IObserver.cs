namespace WeatherStationStandart.Observer;

public interface IObserver<T>
{
    void Update(T data);
}
