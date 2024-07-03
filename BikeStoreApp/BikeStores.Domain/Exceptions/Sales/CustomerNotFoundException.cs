using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.Domain.Exceptions.Sales
{
    public class CustomerNotFoundException : NotFoundException
    {
        public CustomerNotFoundException(int customerId) : base($"Klient {customerId} nie istnieje")
        {
        }
    }
}
