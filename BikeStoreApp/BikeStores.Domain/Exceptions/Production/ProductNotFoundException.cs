using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.Domain.Exceptions.Production
{
    public class ProductNotFoundException : NotFoundException
    {
        public ProductNotFoundException(int productId) : base($"Produkt {productId} nie istnieje")
        {
        }
    }
}
