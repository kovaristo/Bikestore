using BikeStores.Domain.Entities.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.Domain.Exceptions.Sales
{
    public class StaffNotFromStoreException : BadRequestException
    {
        public StaffNotFromStoreException(int staffId, int storeId) : base($"Osoba {staffId} nie należy do personelu sklepu {storeId}")
        {
        }
    }
}
