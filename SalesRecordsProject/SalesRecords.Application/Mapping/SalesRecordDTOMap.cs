﻿using CsvHelper.Configuration;
using SalesRecords.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesRecords.Application.Mapping
{
    internal class SalesRecordDTOMap : ClassMap<SalesRecordDTO>
    {
        public SalesRecordDTOMap()
        {
            Map(m => m.Region).Name("Region");
            Map(m => m.Country).Name("Country");
            Map(m => m.ItemType).Name("Item Type");
            Map(m => m.SalesChannel).Name("Sales Channel");
            Map(m => m.OrderPriority).Name("Order Priority");
            Map(m => m.OrderDate).Name("Order Date");
            Map(m => m.OrderID).Name("Order ID");
            Map(m => m.ShipDate).Name("Ship Date");
            Map(m => m.UnitsSold).Name("Units Sold");
            Map(m => m.UnitPrice).Name("Unit Price");
            Map(m => m.UnitCost).Name("Unit Cost");
            Map(m => m.TotalRevenue).Name("Total Revenue");
            Map(m => m.TotalCost).Name("Total Cost");
            Map(m => m.TotalProfit).Name("Total Profit");
        }
    }
}
