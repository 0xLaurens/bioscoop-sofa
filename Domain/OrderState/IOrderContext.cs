using Data.Observers;

namespace Data.OrderState
{
    public interface IOrderContext
    {
        void Notify(); 
        
        void SetState(IOrderState state);

        DateTime GetScreeningDate();

    }
}
