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
    public class OrderForUpdateDTO
    {
        public string OrderStatus { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }

        public OrderItemQuantityDTO[] OrderItems { get; set; }
    }
}
