using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.Domain.Exceptions.Sales
{
    public class OrderNotFoundException : NotFoundException
    {
        public OrderNotFoundException(int orderId) : base($"Zamówienie {orderId} nie istnieje")
        {
        }
    }
}
