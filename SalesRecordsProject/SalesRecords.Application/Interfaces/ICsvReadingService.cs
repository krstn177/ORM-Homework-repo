using SalesRecords.Domain.DTO;

namespace SalesRecords.Application.Interfaces
{
    public interface ICsvReadingService
    {
        Task ReadRecordsAsync(string filePath);
    }
}