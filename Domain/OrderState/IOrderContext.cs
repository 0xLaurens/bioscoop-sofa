using Data.Observers;

namespace Data.OrderState
{
    public interface IOrderContext
    {
        void SetState(IOrderState state);

        DateTime GetScreeningDate();

    }
}
