using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.Contracts.Sales.Customers
{
    public class CustomerFilterRequest
    {
        public string? Firstname { get; set; }
        public string Lastname { get; set; } = string.Empty;
        public string? Street { get; set; }
        public string? City { get; set; }
    }
}
