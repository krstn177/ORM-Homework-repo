using CsvHelper;
using System.Globalization;
using SalesRecords.Domain.DTO;
using SalesRecords.Application.Mapping;
using SalesRecords.Application.Interfaces;

namespace SalesRecords.Application
{
    public class CsvReadingService : ICsvReadingService
    {
        private readonly IRecordModellingService _recordModellingService;

        public CsvReadingService(IRecordModellingService recordModellingService)
        {
            _recordModellingService = recordModellingService;
        }

        public async Task ReadRecordsAsync()
        {
            using var reader = new StreamReader("./SalesRecords.csv");
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            csv.Context.RegisterClassMap<SalesRecordDTOMap>();
            var records = csv.GetRecords<SalesRecordDTO>();

            await _recordModellingService.ImportSalesRecordsAsync(records);
        }
    }
}
