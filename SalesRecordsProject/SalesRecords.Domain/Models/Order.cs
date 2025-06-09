using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SalesRecords.Domain.Models
{
    public class Order : BaseEntity
    {
        [Required]
        public int OrderNumber { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public DateTime ShipDate { get; set; }

        [Required]
        [StringLength(50)]
        public string OrderPriority { get; set; }

        [Required]
        [StringLength(50)]
        public string SalesChannel { get; set; }

        public virtual ICollection<SalesRecord> SalesRecords { get; set; }
    }
}
