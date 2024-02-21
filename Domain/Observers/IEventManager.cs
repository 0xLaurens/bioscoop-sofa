namespace Data.Observers;

public interface IEventManager
{
    void Subscribe(IEventListener listener);
    void Unsubscribe(IEventListener listener);
    void Notify();
}