namespace Data.Observers;

public interface ISubscriber
{
    void Update(IPublisher manager);
}