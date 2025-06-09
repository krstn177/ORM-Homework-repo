using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesRecords.Application;
using SalesRecords.Infrastructure;

namespace SalesRecords
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();
            RecordModellingService recordModellingService = new RecordModellingService(dbContext);
            CsvReadingService csvReadingService = new CsvReadingService(recordModellingService);

            await csvReadingService.ReadRecordsAsync();

            Console.WriteLine("Done");
        }
    }
}
