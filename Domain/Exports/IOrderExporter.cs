using DocentoScoop.Domain.Models;

namespace Data.Exports
{
    public interface IOrderExporter
    {
        void Export(Order order);

        OrderExportFormat Supports();
    }
}