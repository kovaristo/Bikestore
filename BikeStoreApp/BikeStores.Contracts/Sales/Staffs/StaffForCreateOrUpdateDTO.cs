using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStores.Contracts.Sales.Staffs
{
    public class StaffForCreateOrUpdateDTO
    {
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public short Active { get; set; }
        public int? StoreId { get; set; }
    }
}
