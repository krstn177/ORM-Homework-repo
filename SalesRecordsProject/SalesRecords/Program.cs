using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesRecords.Application;
using SalesRecords.Infrastructure;
using SalesRecords.Infrastructure.Repository;

namespace SalesRecords
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            await using ApplicationDbContext dbContext = new ApplicationDbContext();
            //RecordModellingService recordModellingService = new RecordModellingService(dbContext);
            //CsvReadingService csvReadingService = new CsvReadingService(recordModellingService);

            //await csvReadingService.ReadRecordsAsync();

            var countryRepo = new CountryRepository(dbContext);
            var richCountries2011 = await countryRepo.GetCountriesWithProfit2011Async();
            foreach (var c in richCountries2011)
            {
                Console.WriteLine($"{c.CountryName}: {c.TotalProfit}");
            }

            //var salesRecordRepo = new SalesRecordRepository(dbContext);
            //var itemTypeRevenues = await salesRecordRepo.GetTotalRevenueByItemTypeAsync();
            //foreach (var item in itemTypeRevenues)
            //{
            //    Console.WriteLine($"{item.ItemType}: {item.TotalRevenue}");
            //}

            //var slovakiaProductTypeRevenues = await salesRecordRepo.GetSlovakiaProductTypeRevenueAsync();
            //foreach (var record in slovakiaProductTypeRevenues)
            //{
            //    Console.WriteLine($"Item = \"{record.ItemType}\", Country = \"{record.Country}\", Revenue = {record.TotalRevenue}");
            //}

            //var fastShippedRecords = await salesRecordRepo.GetSalesRecordsWithLessThanOneDayShippingAsync();
            //foreach (var record in fastShippedRecords)
            //{
            //    Console.WriteLine($"{record.Id}: {record.ItemType}, {record.Order.OrderDate} -> {record.Order.ShipDate}");
            //}

            //int recordId = 3;
            //bool deleted = await salesRecordRepo.DeleteWithTransactionAsync(recordId);
            //Console.WriteLine(deleted ? "Deleted successfully." : "Delete failed and rolled back.");

            Console.WriteLine("Done.");

        }
    }
}
