using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.Domain.Exceptions.Sales
{
    public class StaffNotFoundException : NotFoundException
    {
        public StaffNotFoundException(int staffId) : base($"Osoba {staffId} nie istnieje")
        {
        }
    }
}
