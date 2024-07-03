using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.Contracts.Sales.Customers
{
    public class CustomerDTO : BaseAuditableDTO
    {
        public int Id { get; set; }
        public string? Firstname { get; set; }
        public string Lastname { get; set; }
        public string? Phone { get; set; }
        public string Email { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? ZipCode { get; set; }

        public int OrdersCount { get; set; }
    }
}
