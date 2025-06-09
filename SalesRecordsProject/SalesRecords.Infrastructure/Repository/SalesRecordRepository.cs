using Microsoft.EntityFrameworkCore;
using SalesRecords.Domain.Models;
using SalesRecords.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesRecords.Infrastructure.Repository
{
    public class SalesRecordRepository
    {
        private readonly ApplicationDbContext _context;
        public SalesRecordRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(SalesRecord record)
        {
            await _context.SalesRecords.AddAsync(record);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<SalesRecord>> GetAllAsync()
        {
            return await _context.SalesRecords.ToListAsync();
        }
        public async Task<SalesRecord> GetByIdAsync(int id)
        {
            return await _context.SalesRecords.FindAsync(id);
        }
        public async Task UpdateAsync(SalesRecord record)
        {
            _context.SalesRecords.Update(record);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var record = await GetByIdAsync(id);
            if (record != null)
            {
                _context.SalesRecords.Remove(record);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<ItemTypeRevenueDto>> GetTotalRevenueByItemTypeAsync()
        {
            return await _context.SalesRecords
                .GroupBy(sr => sr.ItemType)
                .Select(g => new ItemTypeRevenueDto
                {
                    ItemType = g.Key,
                    TotalRevenue = g.Sum(sr => sr.TotalRevenue)
                })
                .ToListAsync();
        }

        public async Task<List<SlovakiaItemDailyRevenueDto>> GetSlovakiaProductTypeRevenueAsync()
        {
            return await _context.SalesRecords
                .Where(sr => sr.Country.Name == "Slovakia")
                .GroupBy(sr => new { sr.ItemType, sr.Country.Name })
                .Select(g => new SlovakiaItemDailyRevenueDto
                {
                    ItemType = g.Key.ItemType,
                    Country = g.Key.Name,
                    TotalRevenue = g.Sum(sr => sr.TotalRevenue)
                })
                .OrderBy(s => s.TotalRevenue)
                .ToListAsync();
        }

        public async Task<List<SalesRecord>> GetSalesRecordsWithLessThanOneDayShippingAsync()
        {
            // This assumes your table names are lowercase as per your conventions.
            // Adjust table/column names if needed.
            var query = @"
                SELECT sr.*
                FROM salesrecords sr
                INNER JOIN [orders] o ON sr.orderid = o.id
                WHERE DATEDIFF(DAY, o.orderdate, o.shipdate) < 1
            ";

            return await _context.SalesRecords
                .FromSqlRaw(query)
                .Include(sr => sr.Order)
                .Include(sr => sr.Country)
                .ToListAsync();
        }

        public async Task<bool> DeleteWithTransactionAsync(int id)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                await _context.Database.ExecuteSqlRawAsync("SAVE TRANSACTION BeforeDelete");

                var record = await _context.SalesRecords.FindAsync(id);
                if (record == null)
                    return false;

                _context.SalesRecords.Remove(record);
                await _context.SaveChangesAsync();

                await transaction.CommitAsync();
                return true;
            }
            catch (Exception)
            {
                await _context.Database.ExecuteSqlRawAsync("ROLLBACK TRANSACTION BeforeDelete");
                await transaction.RollbackAsync();
                return false;
            }
        }
    }
}
