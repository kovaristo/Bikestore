using BikeStores.Contracts.Sales.Customers;
using BikeStores.Contracts.Sales.Staffs;
using BikeStores.Contracts.Sales.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.Contracts.Sales.Orders
{
    public class OrderFilterRequest
    {
        public int? StoreId { get; set; }
        public int? CustomerId { get; set; }
        public string? OrderStatus { get; set; }
        public DateTime? OrderDate { get; set; }
    }
}
