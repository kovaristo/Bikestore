using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.Contracts.Production.Products
{
    public class ProductForCreateOrUpdateDTO
    {
        public string Name { get; set; }

        public int BrandId { get; set; }
        public int CategoryId { get; set; }

        public short ModelYear { get; set; }
        public decimal ListPrice { get; set; }
    }
}
