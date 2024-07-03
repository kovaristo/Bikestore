using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.Domain.Exceptions.Production
{
    public class BrandNotFoundException : NotFoundException
    {
        public BrandNotFoundException(int brandId) : base($"Marka {brandId} nie istnieje")
        {
        }
    }
}
