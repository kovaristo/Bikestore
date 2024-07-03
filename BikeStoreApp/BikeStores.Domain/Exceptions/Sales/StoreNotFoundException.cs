using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.Domain.Exceptions.Sales
{
    public class StoreNotFoundException : NotFoundException
    {
        public StoreNotFoundException(int storeId) : base($"Sklep {storeId} nie istnieje")
        {
        }
    }
}
