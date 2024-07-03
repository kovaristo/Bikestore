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
    public class OrderForCreateDTO
    {
        public int StoreId { get; set; }
        public int StaffId { get; set; }
        public int? CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public OrderItemQuantityDTO[] OrderItems { get; set; }
    }
}
