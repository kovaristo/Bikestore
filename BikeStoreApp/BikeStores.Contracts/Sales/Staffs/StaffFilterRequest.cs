using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.Contracts.Sales.Staffs
{
    public class StaffFilterRequest
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public short Active { get; set; }
        public int? StoreId { get; set; }
    }
}
