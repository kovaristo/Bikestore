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
    public class OrderDTO
    {
        public int Id { get; set; }
        public int StoreId { get; set; }
        public int StaffId { get; set; }
        public int? CustomerId { get; set; }
        public string OrderStatus { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }

        public CustomerInfoDTO Customer { get; set; }
        public OrderItemInfoDTO[] OrderItems { get; set; }
        public StaffInfoDTO Staff { get; set; }
        public StoreInfoDTO Store { get; set; }
    }
}
