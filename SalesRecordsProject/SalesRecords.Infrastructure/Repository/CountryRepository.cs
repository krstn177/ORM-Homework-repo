using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesRecords.Domain.Models;
using SalesRecords.Domain.DTO;

namespace SalesRecords.Infrastructure.Repository
{
    public class CountryRepository
    {
        private readonly ApplicationDbContext _context;

        public CountryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<CountryProfitDto>> GetCountriesWithProfit2011Async()
        {
            var result = await _context.Countries
                .Select(country => new CountryProfitDto
                {
                    CountryName = country.Name,
                    TotalProfit = country.SalesRecords
                        .Where(sr => sr.Order.OrderDate.Year == 2011)
                        .Sum(sr => sr.TotalProfit)
                })
                .Where(dto => dto.TotalProfit > 200000)
                .OrderBy(dto => dto.CountryName)
                .ToListAsync();

            return result;
        }
    }
}