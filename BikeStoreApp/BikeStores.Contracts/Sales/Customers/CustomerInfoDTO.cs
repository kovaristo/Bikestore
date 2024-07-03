using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.Contracts.Sales.Customers
{
    public class CustomerInfoDTO
    {
        public int Id { get; set; }
        public string? Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
    }
}
