using SalesRecords.Domain.DTO;

namespace SalesRecords.Application.Interfaces
{
    public interface IRecordModellingService
    {
        Task ImportSalesRecordsAsync(IEnumerable<SalesRecordDTO> records);
    }
}