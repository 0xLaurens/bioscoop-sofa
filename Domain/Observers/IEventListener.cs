namespace Data.Observers;

public interface IEventListener
{
    void Update(IEventManager manager);
}