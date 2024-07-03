using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.Contracts.Production.Products
{
    public class ProductFilterRequest
    {
        public string Name { get; set; } = string.Empty;
        public short[]? ModelYears { get; set; }
        public decimal? MinListPrice { get; set; }
        public decimal? MaxListPrice { get; set; }
    }
}
