using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesRecords.Domain.Models
{
    public class SalesRecord : BaseEntity
    {
        [Required]
        public int OrderId { get; set; }
        
        [Required]
        public int CountryId { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string ItemType { get; set; }
        
        [Required]
        [Range(1, int.MaxValue)]
        public int UnitsSold { get; set; }
        
        [Required]
        [Range(0.01, double.MaxValue)]
        public double UnitPrice { get; set; }
        
        [Required]
        [Range(0.01, double.MaxValue)]
        public double UnitCost { get; set; }
        
        public double TotalRevenue { get; set; }
        public double TotalCost { get; set; }
        public double TotalProfit { get; set; }
        
        public Order Order { get; set; }
        public Country Country { get; set; }
    }
}
