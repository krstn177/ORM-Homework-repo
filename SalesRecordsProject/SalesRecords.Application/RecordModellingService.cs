using SalesRecords.Domain.Models;
using SalesRecords.Domain.DTO;
using SalesRecords.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesRecords.Infrastructure;

namespace SalesRecords.Application
{
    public class RecordModellingService : IRecordModellingService
    {
        private readonly ApplicationDbContext _dbContext;

        public RecordModellingService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task ImportSalesRecordsAsync(IEnumerable<SalesRecordDTO> dtos)
        {
            // Caches for deduplication
            var regionCache = new Dictionary<string, Region>(StringComparer.OrdinalIgnoreCase);
            var countryCache = new Dictionary<(string Country, string Region), Country>();
            var orderCache = new Dictionary<int, Order>();
            var salesRecordCache = new HashSet<(int OrderNumber, string Country, string ItemType, int UnitsSold)>();

            var salesRecords = new List<SalesRecord>();

            foreach (var dto in dtos)
            {
                // Region
                if (!regionCache.TryGetValue(dto.Region, out var region))
                {
                    region = new Region { Name = dto.Region, Countries = new List<Country>() };
                    regionCache[dto.Region] = region;
                }

                // Country
                var countryKey = (dto.Country, dto.Region);
                if (!countryCache.TryGetValue(countryKey, out var country))
                {
                    country = new Country { Name = dto.Country, Region = region };
                    countryCache[countryKey] = country;
                    region.Countries.Add(country);
                }

                // Order
                if (!orderCache.TryGetValue(dto.OrderID, out var order))
                {
                    order = new Order
                    {
                        OrderNumber = dto.OrderID,
                        OrderDate = dto.OrderDate,
                        ShipDate = dto.ShipDate,
                        OrderPriority = dto.OrderPriority,
                        SalesChannel = dto.SalesChannel
                    };
                    orderCache[dto.OrderID] = order;
                }

                // SalesRecord deduplication
                var salesRecordKey = (dto.OrderID, dto.Country, dto.ItemType, dto.UnitsSold);
                if (!salesRecordCache.Contains(salesRecordKey))
                {
                    var salesRecord = new SalesRecord
                    {
                        Country = country,
                        Order = order,
                        ItemType = dto.ItemType,
                        UnitsSold = dto.UnitsSold,
                        UnitPrice = dto.UnitPrice,
                        UnitCost = dto.UnitCost,
                        TotalRevenue = dto.TotalRevenue,
                        TotalCost = dto.TotalCost,
                        TotalProfit = dto.TotalProfit
                    };
                    salesRecords.Add(salesRecord);
                    salesRecordCache.Add(salesRecordKey);
                }
            }

            // Add to context
            _dbContext.Regions.AddRange(regionCache.Values);
            _dbContext.Countries.AddRange(countryCache.Values);
            _dbContext.Orders.AddRange(orderCache.Values);
            _dbContext.SalesRecords.AddRange(salesRecords);

            await _dbContext.SaveChangesAsync();
        }
    }
}
