using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.Contracts.Sales.Stores
{
    public class StoreDTO : BaseAuditableDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? ZipCode { get; set; }

        public int OrdersCount { get; set; }
        public int ProductsCount { get; set; }
        public int StaffsCount { get; set; }
    }
}
